using System;
using TerribleEngine.Events;
using IEvent = TerribleEditorV2.Events.IEvent;

namespace TerribleEditorV2.Services
{
    public interface IEventManager
    {
        void RaiseEvent<T>(T e) where T : IEvent;
        void RegisterEventListener<T>(Action<T> handler) where T : IEvent;
    }
}