﻿using _Project.Infrastructure.AssetsProviders;
using _Project.Infrastructure.AssetsProviders.Abstract;
using _Project.Scripts.Infrastructure.ApplicationObservers.Runtime;
using _Project.Scripts.Infrastructure.ApplicationObservers.Runtime.Focus;
using _Project.Scripts.Infrastructure.ApplicationObservers.Runtime.Pause;
using _Project.Scripts.Infrastructure.ApplicationObservers.Runtime.Quit;
using CollectionsPooling;
using GameTasks.Core;
using ServiceLocator.Core;
using Services.States;
using UnityEngine;
using WindowsSystem.Core.Managers;

namespace _Project.Infrastructure.Registrators
{
    public class InfrastructureRegistrator : BaseMonoServicesRegistrator
    {
        [Header("Core")] [SerializeField] private ApplicationStateMachine _stateMachine;
        [SerializeField] private TasksLoader _tasksLoader;
        [SerializeField] private WindowsController _windowsController;
        [SerializeField] private UIMainController _uiMainController;

        [Header("Observers")] [SerializeField] private Updater _updater;
        [SerializeField] private ApplicationPauseObserver _applicationPauseObserver;
        [SerializeField] private ApplicationFocusObserver _applicationFocusObserver;
        [SerializeField] private ApplicationQuitObserver _applicationQuitObserver;

        public override void Register()
        {
            Locator.Register<IAssetsProvider>(new AssetsProvider());
            
            Locator.Register(_stateMachine);
            Locator.Register<StateMachineMonoBehaviour>(_stateMachine);
            Locator.Register(_tasksLoader);
            Locator.Register(_windowsController);
            Locator.Register(_uiMainController);
            Locator.Register<ICollectionsPoolService>(new CollectionsPoolService());
            
            Locator.Register<IUpdater>(_updater);
            Locator.Register<IApplicationPauseObserver>(_applicationPauseObserver);
            Locator.Register<IApplicationFocusObserver>(_applicationFocusObserver);
            Locator.Register<IApplicationQuitObserver>(_applicationQuitObserver);
        }
    }
}