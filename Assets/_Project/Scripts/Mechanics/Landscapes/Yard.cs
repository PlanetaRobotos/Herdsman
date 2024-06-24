using _Project.Infrastructure.Mechanics;
using UnityEngine;

namespace _Project.Mechanics.Landscapes
{
    public class Yard : MonoBehaviour, ITriggable, IYard
    {
        [SerializeField] private SimpleObserver _observer;
        [field: SerializeField] public Collider2D GrazeCollider { get; private set; }
        
        public SimpleObserver Observer => _observer;

        public Transform Transform => transform;

        public void Initialize()
        {
            _observer.Setup(this);
        }

        public void TriggerEnter(Collider2D other)
        {
        }

        public void TriggerExit(Collider2D other)
        {
        }
    }
}