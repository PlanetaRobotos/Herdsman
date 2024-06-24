using System.Collections.Generic;
using _Project.Mechanics.Entities.Models.Formations;
using UnityEngine;

namespace _Project.Mechanics.Entities.Formations
{
    public class LineFormation : Formation
    {
        private readonly float _spacing;
        private readonly int _amount;

        public LineFormation(LineFormationConfig formation, int amount)
        {
            _amount = amount;
            _spacing = formation.Spacing;
        }

        public override List<Vector2> CalculatePositions(Vector2 center, List<Transform> animals)
        {
            List<Vector2> positions = new();

            for (int i = 0; i < _amount; i++)
            {
                float offsetX = i * _spacing;
                Vector2 position = new(-offsetX, 0);
                positions.Add(position);
            }

            return positions;
        }
    }
}