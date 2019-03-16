using System;
using System.Collections.Generic;
using System.ComponentModel;
using TerribleEngine.Events;

namespace TerribleEngine.ECS
{

    public class EventManager
    {
        private Dictionary<Type, List<Action<object>>> _eventHandlers;

        private Queue<IEvent> _events;

        public EventManager()
        {
            _eventHandlers = new Dictionary<Type, List<Action<object>>>();
            _events = new Queue<IEvent>();
        }

        public void RegisterEventListener<T>(Action<object> handler) where T : IEvent
        {
            var eventType = typeof(T);
            if (!_eventHandlers.ContainsKey(eventType))
            {
                _eventHandlers.Add(eventType, new List<Action<object>>());
            }

            _eventHandlers[eventType].Add(handler);
        }

        public void RaiseEvent<T>(T e) where T : IEvent
        {
            _events.Enqueue(e);
        }

        public void Update()
        {
            while (_events.Count > 0)
            {
                var e = _events.Dequeue();
                var type = e.GetType();
                var handlers = _eventHandlers[type];
                foreach (var handler in handlers)
                {
                    handler?.Invoke(e);
                }
            }
        }
    }
}