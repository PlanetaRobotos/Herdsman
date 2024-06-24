namespace _Project.Mechanics.Entities.Models
{
    public interface IEntity
    {
        EntityType EntityType { get; }
        string Name { get; }
    }
}