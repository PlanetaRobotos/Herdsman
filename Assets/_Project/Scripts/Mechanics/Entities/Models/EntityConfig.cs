using System;
using UnityEngine;

namespace _Project.Mechanics.Entities.Models
{
    [Serializable]
    public class EntityConfig
    {
        [field: SerializeField] public string AddressableKey { get; private set; }
        [field: SerializeField] public Vector2 DefaultSpawnPosition { get; private set; }
    }
}