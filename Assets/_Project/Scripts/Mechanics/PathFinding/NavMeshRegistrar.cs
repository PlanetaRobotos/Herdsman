using NavMeshPlus.Components;
using ServiceLocator.Core;
using UnityEngine;

namespace _Project.Mechanics.PathFinding
{
    public class NavMeshRegistrar: BaseMonoServicesRegistrator
    {
        [SerializeField] private NavMeshSurface _navMeshSurface;
        
        public override void Register()
        {
            Locator.Register(new NavMeshController(_navMeshSurface));
        }
    }
}