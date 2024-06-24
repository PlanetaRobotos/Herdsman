using System.Threading;
using _Project.Configs;
using _Project.GameConstants;
using _Project.Infrastructure.Tasks;
using _Project.Mechanics.Entities;
using _Project.Mechanics.Entities.Tasks;
using _Project.Mechanics.PathFinding.Tasks;
using _Project.Services.AvatarService.Core;
using _Project.Windows.HUD;
using _Project.Windows.Loading;
using Constellation.SceneManagement;
using GameTasks;
using GameTasks.Core;
using Services.States;
using WindowsSystem.Core.Managers;

namespace _Project.Infrastructure.States
{
    public class LoadApplicationState : IState
    {
        [Inject] private readonly ApplicationStateMachine _stateMachine;
        [Inject] private readonly IScenesManager _scenesManager;
        [Inject] private readonly TasksLoader _tasksLoader;
        [Inject] private readonly WindowsController _windowsController;
        [Inject] private readonly ConfigsController _configsController;
        [Inject] private readonly IAvatarService _avatarService;
        [Inject] private readonly FollowBehaviour _followBehaviour;

        private CancellationTokenSource _cts;

        public void Enter()
        {
            _cts = new CancellationTokenSource();

            _tasksLoader.DoTasks(GetTasks()).OnDone(_ => _stateMachine.Enter<GameplayState>());
        }

        public void Exit()
        {
            if (_tasksLoader.enabled)
                _tasksLoader.AbortTasks();
        }

        private ITask[] GetTasks()
        {
            ITask[] tasks =
            {
                new LoadConfigsTask(_configsController),
                new MakeActionTask<IAvatarService>(_avatarService, x => x.LoadSpriteProviders()),
                new OpenWindowTask<LoadingWindow>(_windowsController, WindowsConstants.LOADING_WINDOW, true),
                new OpenWindowTask<HUDWindow>(_windowsController, WindowsConstants.HUD_WINDOW, true),
                new MakeActionTaskAsync(
                    () => _scenesManager.LoadScene((byte)SceneLibraryConstants.GAMEPLAY, _cts.Token)),
                new LoadLandscapeTaskAsync(),
                new LoadYardsTaskAsync(),
                new LoadNavMeshTask(),
                new LoadEntitiesTaskAsync(),
                new MakeActionTask<FollowBehaviour>(_followBehaviour, x => x.Initialize()),
            };
            return tasks;
        }
    }
}