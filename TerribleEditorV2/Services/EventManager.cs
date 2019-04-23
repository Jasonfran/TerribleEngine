using System;
using System.Collections.Generic;
using TerribleEditorV2.Events;

namespace TerribleEditorV2.Services
{

    public class EventManager : IEventManager
    {
        private Dictionary<Type, List<Action<object>>> _eventHandlers;

        public EventManager()
        {
            _eventHandlers = new Dictionary<Type, List<Action<object>>>();
        }

        public void RegisterEventListener<T>(Action<T> handler) where T : IEvent
        {
            var eventType = typeof(T);
            if (!_eventHandlers.ContainsKey(eventType))
            {
                _eventHandlers.Add(eventType, new List<Action<object>>());
            }

            var eventHandler = new Action<object>(obj => handler.Invoke((T)obj));
            _eventHandlers[eventType].Add(eventHandler);
        }

        public void RaiseEvent<T>(T e) where T : IEvent
        {
            var type = e.GetType();
            _eventHandlers.TryGetValue(type, out var handlers);

            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    handler?.Invoke(e);
                }
            }
        }
    }
}