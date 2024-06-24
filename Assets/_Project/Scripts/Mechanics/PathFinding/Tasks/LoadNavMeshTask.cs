namespace _Project.Mechanics.PathFinding.Tasks
{
    public class LoadNavMeshTask : BaseTask
    {
        [Inject] private NavMeshController _navMeshController;
        
        public override ITask Do()
        {
            _navMeshController.BuildNavMesh();
            Complete();
            return this;
        }
    }
}