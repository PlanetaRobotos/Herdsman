using System.Collections.Generic;
using UnityEngine;

namespace _Project.Mechanics.Entities.Formations
{
    public interface IFormation
    {
        List<Vector2> CalculatePositions(Vector2 center, List<Transform> data);
    }
}