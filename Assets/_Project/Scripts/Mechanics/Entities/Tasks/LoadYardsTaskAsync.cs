using _Project.Mechanics.Landscapes.Configs;
using _Project.Mechanics.Landscapes.Factories;
using Cysharp.Threading.Tasks;

namespace _Project.Mechanics.Entities.Tasks
{
    public class LoadYardsTaskAsync : AsyncTask
    {
        private const int DefaultYardIndex = 0;
        
        [Inject] private YardFactory _yardsFactory;
        [Inject] private YardsConfig _yardsConfig;
        
        protected override async UniTask DoAsync()
        {
            var template = await _yardsFactory.Load(_yardsConfig.AssetReferences[DefaultYardIndex]);

            foreach (var yard in _yardsConfig.Yards) 
                _yardsFactory.Instantiate(template, yard);
        }
    }
}