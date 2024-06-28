using _Project.Infrastructure.AssetsProviders.Abstract;
using _Project.Mechanics.Landscapes.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Mechanics.Landscapes.Factories
{
    public class GameFieldFactory : ISimpleFactory<GameObject, LandscapeConfig>
    {
        [Inject] private IAssetsProvider AssetsProvider { get; }

        public async UniTask<GameObject> Load(string key)
        {
            var go = await AssetsProvider.LoadAssetAsync<GameObject>(key);
            return go;
        }

        public GameObject Instantiate(GameObject template, LandscapeConfig landscapeConfig, Transform parent)
        {
            var instance = Object.Instantiate(template, landscapeConfig.SpawnPosition, Quaternion.identity);
            instance.transform.localScale = landscapeConfig.Scale;
            instance.transform.SetParent(parent);
            return instance;
        }
    }

    public class YardsFactory : ISimpleFactory<Yard, YardConfig>
    {
        [Inject] private IAssetsProvider AssetsProvider { get; }

        public async UniTask<Yard> Load(string key)
        {
            var go = await AssetsProvider.LoadAssetAsync<GameObject>(key);
            return go.GetComponent<Yard>();
        }

        public Yard Instantiate(Yard template, YardConfig yardConfig, Transform parent)
        {
            var instance = Object.Instantiate(template, yardConfig.SpawnPosition, Quaternion.identity);
            instance.transform.localScale = yardConfig.Scale;
            instance.transform.SetParent(parent);
            instance.Initialize();
            return instance;
        }
    }
}