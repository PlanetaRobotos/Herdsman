using System;

namespace _Project.Scripts.Infrastructure.ApplicationObservers.Runtime.Focus
{
    public interface IApplicationFocusObserver
    {
        void AddSubscriber(Action<bool> subscriber);
        void RemoveSubscriber(Action<bool> subscriber);
    }
}