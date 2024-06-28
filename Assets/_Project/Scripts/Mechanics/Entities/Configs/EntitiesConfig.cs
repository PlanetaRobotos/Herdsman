using _Project.Mechanics.Entities.Formations;
using _Project.Mechanics.Entities.Models;
using ManagedReference;
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

        [SerializeReference, ManagedReference, Space]
        private IFormation _followScript;

        public IFormation FollowScript => _followScript;
    }
}