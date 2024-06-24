using System.Collections.Generic;
using _Project.Mechanics.Entities.Models.Formations;
using UnityEngine;

namespace _Project.Mechanics.Entities.Formations
{
    public class CircleFormation : Formation
    {
        private readonly float _spacingAngle;
        private readonly int _amount;
        private readonly float _radius;

        public CircleFormation(CircleFormationConfig formation, int amount)
        {
            _spacingAngle = formation.SpacingAngle;
            _amount = amount;
            _radius = formation.Radius;
        }

        public override List<Vector2> CalculatePositions(Vector2 center, List<Transform> animals)
        {
            List<Vector2> semiCirclePositions = new();

            float angleStep = _spacingAngle / (_amount - 1);

            for (int i = 0; i < _amount; i++)
            {
                float angle = Mathf.Deg2Rad * (angleStep * i - _spacingAngle / 2);
                float x = center.x + _radius * Mathf.Cos(angle);
                float y = center.y + _radius * Mathf.Sin(angle);
                semiCirclePositions.Add(new Vector2(x, y));
            }

            return semiCirclePositions;
        }
    }
}