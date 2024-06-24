using _Project.Infrastructure.AssetsProviders.Abstract;
using _Project.Mechanics.Landscapes.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Mechanics.Landscapes.Factories
{
    public class GameFieldFactory
    {
        [Inject] private IAssetsProvider AssetsProvider { get; }
        
        private readonly LandscapesConfig _landscapesConfig;

        public GameFieldFactory(LandscapesConfig landscapesConfig)
        {
            _landscapesConfig = landscapesConfig;
        }

        public async UniTask<GameObject> Load(string key)
        {
            var go = await AssetsProvider.LoadAssetAsync<GameObject>(key);
            return go;
        }

        public GameObject Instantiate(GameObject template, LandscapeConfig landscapeConfig)
        {
            var instance = Object.Instantiate(template, landscapeConfig.SpawnPosition, Quaternion.identity);
            instance.transform.localScale = landscapeConfig.Scale;
            return instance;
        }
    }
}