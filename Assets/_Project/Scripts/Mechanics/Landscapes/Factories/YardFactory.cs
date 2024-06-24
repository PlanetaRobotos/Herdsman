using _Project.Infrastructure.AssetsProviders.Abstract;
using _Project.Mechanics.Landscapes.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Mechanics.Landscapes.Factories
{
    public class YardFactory : IYardFactory
    {
        [Inject] private IAssetsProvider AssetsProvider { get; }
        
        private readonly YardsConfig _yardsConfig;

        public YardFactory(YardsConfig yardsConfig)
        {
            _yardsConfig = yardsConfig;
        }

        public async UniTask<Yard> Load(string key)
        {
            var go = await AssetsProvider.LoadAssetAsync<GameObject>(key);
            return go.GetComponent<Yard>();
        }

        public IYard Instantiate(Yard template, YardConfig yardConfig)
        {
            var instance = Object.Instantiate(template, yardConfig.SpawnPosition, Quaternion.identity);
            instance.transform.localScale = yardConfig.Scale;
            instance.Initialize();
            return instance;
        }
    }
}