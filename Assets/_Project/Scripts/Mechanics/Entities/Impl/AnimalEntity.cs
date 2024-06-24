/*using _Project.Mechanics.Entities.Spawners;
using _Project.Scripts.Architecture.Behaviours;
using UnityEngine;

namespace _Project.Mechanics.Entities
{
    public class AnimalEntity : BaseEntity, ITriggable
    {
        [SerializeField] private SimpleObserver _simpleObserver;

        public bool IsFollowing { get; private set; }
        public Transform Target { get; private set; }
        private FollowBehaviour _followBehaviour;

        public void Initialize(FollowBehaviour followBehaviour)
        {
            _followBehaviour = followBehaviour;
            _simpleObserver.Setup(this);
        }

        public void TriggerEnter(Collider2D other)
        {
            if (other.TryGetComponent(out SimpleObserver observer) && observer.Parent is PlayerEntity player)
            {
                FollowPlayer(player);
            }
            
            if (other.TryGetComponent(out Yard yard))
            {
                EnterYardZone(yard);
            }
        }

        private void EnterYardZone(Yard yard)
        {
            Target = yard.transform;

            var randPos = yard.Collider.GetRandomPosition();
            
        }

        public void TriggerExit(Collider2D other)
        {
        }

        private void FollowPlayer(PlayerEntity target)
        {
            if (_followBehaviour != null && _followBehaviour.AddToGroup(this))
            {
                Target = target.GetAvailableFollowPosition();
                IsFollowing = true;
            }
        }

        public void StopFollowing()
        {
            IsFollowing = false;
            Target = null;
        }
    }
}*/