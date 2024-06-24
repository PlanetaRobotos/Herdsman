using _Project.Mechanics.Entities.Models;
using _Project.Mechanics.Entities.Models.Formations;
using MVVM.Adapters.Float;
using UnityEngine;

namespace _Project.Mechanics.Entities.Configs
{
    [CreateAssetMenu(fileName = "EntitiesConfig", menuName = "Entities/EntitiesConfig")]
    public class EntitiesConfig : ScriptableObject
    {
        [field: SerializeField] public EntityConfig[] Entities { get; private set; }

        [field: SerializeField, Header("Animals")] public LayerMask SpawnLayerMask { get; private set; }
        [field: SerializeField] public float CheckSpawnRadius { get; private set; }
        [field: SerializeField] public int MaxAnimalsAmount { get; private set; }
        [field: SerializeField] public int MaxFollowAmount { get; private set; }
        [field: SerializeField] public MinMaxValue SpawnDelayInterval { get; private set; }
        [field: SerializeField, Header("Formations")] public CircleFormationConfig CircleFormation { get; private set; }
        [field: SerializeField] public LineFormationConfig LineFormation { get; private set; }
        [field: SerializeField, Space] public FollowType FollowType { get; private set; }
    }
}