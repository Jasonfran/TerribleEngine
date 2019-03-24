using System;
using TerribleEngine.Events;

namespace TerribleEngine.ECS
{
    public interface IEventManager
    {
        void RaiseEvent<T>(T e) where T : IEvent;
        void RegisterEventListener<T>(Action<object> handler) where T : IEvent;
        void Update();
    }
}