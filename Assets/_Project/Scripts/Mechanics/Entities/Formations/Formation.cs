using System.Collections.Generic;
using UnityEngine;

namespace _Project.Mechanics.Entities.Formations
{
    public abstract class Formation
    {
        public abstract List<Vector2> CalculatePositions(Vector2 center, List<Transform> animals);
    }
}