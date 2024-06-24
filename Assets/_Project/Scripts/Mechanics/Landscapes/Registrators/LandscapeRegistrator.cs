using _Project.Mechanics.Landscapes.Configs;
using _Project.Mechanics.Landscapes.Factories;
using _Project.Mechanics.Landscapes.Providers;
using ServiceLocator.Core;
using UnityEngine;

namespace _Project.Mechanics.Landscapes.Registrators
{
    public class LandscapeRegistrator: BaseMonoServicesRegistrator
    {
        [SerializeField] private LandscapesConfig _landscapesConfig;
        [SerializeField] private YardsConfig _yardsConfig;
        
        public override void Register()
        {
            Locator.Register(_landscapesConfig);
            Locator.Register(_yardsConfig);
            
            Locator.Register(new GameFieldFactory(_landscapesConfig));
            Locator.Register(new YardFactory(_yardsConfig));
            Locator.Register(new LandscapeProvider());
            Locator.Register(new YardsProvider());
        }
    }
}