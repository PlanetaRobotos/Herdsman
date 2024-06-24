using System;
using UnityEngine;

namespace _Project.Infrastructure.Inputs.Abstract
{
    public interface IInputObserver
    {
        event Action<Vector2> OnClick;
    }
}