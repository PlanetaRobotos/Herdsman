using System;

namespace _Project.Scripts.Infrastructure.ApplicationObservers.Runtime.Pause
{
    public interface IApplicationPauseObserver
    {
        void AddSubscriber(Action<bool> subscriber);
        void RemoveSubscriber(Action<bool> subscriber);
    }
}