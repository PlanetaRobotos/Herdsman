using System;
using _Project.Mechanics.Entities.Abstract;
using _Project.Mechanics.Entities.AI.AIEntities;
using _Project.Mechanics.Entities.Constants;
using UnityEngine;

namespace _Project.Mechanics.Entities.AI.States
{
    public class GrazeAIState : BaseAIState
    {
        private readonly AIBase _ai;
        private Vector2 _targetPosition;

        public GrazeAIState(AIBase ai) : base(ai.gameObject)
        {
            _ai = ai;
        }

        public override void EnterState(object[] objects)
        {
            _targetPosition = objects[0] as Vector2? ?? default;
        }

        public override Type FixedTick()
        {
            if (!_ai.Movement.IsNearby(_targetPosition, EntitiesConstants.MIN_DISTANCE_TO_TARGET))
            {
                _ai.Movement.Move(_targetPosition);
            }
            else
            {
                return typeof(DeathAIState);
            }

            return null;
        }
    }
}