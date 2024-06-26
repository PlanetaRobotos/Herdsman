using System;
using System.Collections.Generic;
using _Project.Infrastructure.Mechanics;
using _Project.Mechanics.Entities.Abstract;
using _Project.Mechanics.Entities.AI.Movement;
using _Project.Mechanics.Entities.AI.States;
using _Project.Mechanics.Entities.Configs;
using _Project.Mechanics.Entities.Impl;
using _Project.Mechanics.Entities.Spawners;
using _Project.Mechanics.Landscapes;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Mechanics.Entities.AI.AIEntities
{
    public class SimpleAI : AIBase
    {
        [SerializeField] private AnimalEntityConfig _animalEntityConfig;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        private PlayerEntity.FollowPoint _followPoint;
        private EntitiesProvider _entitiesProvider;
        private bool _isUsed;

        public override IAIMovement Movement { get; protected set; }
        public override int Cost { get; protected set; }

        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        public override void Initialize(FollowBehaviour followBehaviour, EntitiesProvider entitiesProvider,
            Collider2D spawnArea, EntitiesConfig entitiesConfig)
        {
            _entitiesProvider = entitiesProvider;
            base.Initialize(followBehaviour, entitiesProvider, spawnArea, entitiesConfig);

            SpawnPoint = transform.position;
            UseHealthUI = false;

            Movement = new AIMovement(_animalEntityConfig.FollowSpeed, _animalEntityConfig.InteractDistance, transform);
            Cost = _animalEntityConfig.Cost;
            
            _navMeshAgent.speed = _animalEntityConfig.PatrolSpeed;
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }

        public override void InitializeStateMachine()
        {
            var cols = GetComponents<Collider2D>();
            var states = new Dictionary<Type, BaseAIState>
            {
                { typeof(SpawnAIState), new SpawnAIState(this, cols, null) },
                { typeof(IdleAIState), new IdleAIState(this, _animalEntityConfig.StartPatrolDelay) },
                { typeof(ChaseTargetAIState), new ChaseTargetAIState(this, _followBehaviour) },
                { typeof(GrazeAIState), new GrazeAIState(this) },
                { typeof(DeathAIState), new DeathAIState(this, cols, _animalEntityConfig.DeadDelay) },
                { typeof(CirclePatrolAIState), new CirclePatrolAIState(this, _animalEntityConfig.FindNextPointDelay) },
            };

            StateMachine.SetStates(states);
        }

        public override bool IsSeeHero() => true;
        public override bool IsUseInteraction() => true;

        public override void TriggerEnter(Collider2D other)
        {
            if (other.TryGetComponent(out SimpleObserver observer))
            {
                if (observer.Parent is PlayerEntity player && Target == null && _followBehaviour.CanBeAddedToGroup(this) && !_isUsed)
                {
                    _followPoint = player.GetAvailableFollowPosition();
                    if (_followPoint != null)
                    {
                        _isUsed = true;
                        Target = _followPoint.trans;
                        _navMeshAgent.enabled = false;
                    }
                }
                else if (observer.Parent is IYard yard && Target != null)
                {
                    _entitiesProvider.AddScore(this);
                    _entitiesProvider.Animals.Remove(this);
                    _entitiesProvider.PlayerEntity.SetAvailablePoint(_followPoint.Index, true);
                    _followPoint = null;
                    Target = null;
                    _followBehaviour.RemoveFromGroup(this);
                    StateMachine.ChangeState(typeof(GrazeAIState), yard.GrazeCollider.GetRandomPosition());
                }
            }
        }

        public override void TriggerExit(Collider2D other)
        {
            
        }

        public override void SetData(string savePath)
        {
        }
    }
}