using NavMeshPlus.Components;

namespace _Project.Mechanics.PathFinding
{
    public class NavMeshController
    {
        private readonly NavMeshSurface _navMeshSurface;

        public NavMeshController(NavMeshSurface navMeshSurface)
        {
            _navMeshSurface = navMeshSurface;
        }

        public void BuildNavMesh()
        {
            _navMeshSurface.BuildNavMesh();
        }
    }
}