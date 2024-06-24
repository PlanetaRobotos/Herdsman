using System;
using UnityEngine;

namespace _Project.Mechanics.Entities.Models.Formations
{
    [Serializable]
    public class LineFormationConfig
    {
        [field: SerializeField] public float Spacing { get; private set; }
    }
}