using _Project.Mechanics.Landscapes;
using _Project.Mechanics.Landscapes.Configs;
using _Project.Mechanics.Landscapes.Factories;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Mechanics.Entities.Tasks
{
    public class LoadYardsTaskAsync : AsyncTask
    {
        private const int DefaultYardIndex = 0;
        
        [Inject] private ISimpleFactory<Yard, YardConfig> _yardsFactory;
        [Inject] private YardsConfig _yardsConfig;
        
        protected override async UniTask DoAsync()
        {
            var template = await _yardsFactory.Load(_yardsConfig.AssetReferences[DefaultYardIndex]);

            var parent = new GameObject("Yards");
            foreach (var yard in _yardsConfig.Yards)
            {
                _yardsFactory.Instantiate(template, yard, parent.transform);
            }
        }
    }
}