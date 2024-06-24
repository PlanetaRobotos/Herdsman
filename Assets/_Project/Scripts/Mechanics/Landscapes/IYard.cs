using _Project.Infrastructure.Mechanics;
using UnityEngine;

namespace _Project.Mechanics.Landscapes
{
    public interface IYard
    {
        SimpleObserver Observer { get; }
        Collider2D GrazeCollider { get; }
        Transform Transform { get; }
        void Initialize();
    }
}