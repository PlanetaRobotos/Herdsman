using _Project.Mechanics.Landscapes.Configs;
using _Project.Mechanics.Landscapes.Factories;
using _Project.Mechanics.Landscapes.Providers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Mechanics.Entities.Tasks
{
    public class LoadLandscapeTaskAsync : AsyncTask
    {
        private const int DefaultLandscapeIndex = 0;
        
        [Inject] private ISimpleFactory<GameObject, LandscapeConfig> _gameFieldFactory;
        [Inject] private LandscapesConfig _landscapesConfig;
        [Inject] private LandscapeProvider _landscapeProvider;
        
        protected override async UniTask DoAsync()
        {
            var template = await _gameFieldFactory.Load(_landscapesConfig.AssetReferences[DefaultLandscapeIndex]);
            _landscapeProvider.CurrentLandscape = _gameFieldFactory.Instantiate(template, _landscapesConfig.Landscapes[DefaultLandscapeIndex], new GameObject("Landscapes").transform);
        }
    }
}