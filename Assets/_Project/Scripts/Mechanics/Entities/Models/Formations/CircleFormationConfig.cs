using System;
using UnityEngine;

namespace _Project.Mechanics.Entities.Models.Formations
{
    [Serializable]
    public class CircleFormationConfig
    {
        [field: SerializeField] public float SpacingAngle { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
    }
}