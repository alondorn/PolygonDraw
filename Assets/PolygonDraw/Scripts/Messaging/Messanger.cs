using AlonDorn.PolygonDraw;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace AlonDorn.Messaging
{
    public class Messanger
    {
        static Dictionary<AppEvents, UnityEvent> events = new Dictionary<AppEvents, UnityEvent>();

        public static void Subscribe(AppEvents eventType, UnityAction listener)
        {
            UnityEvent currentEvent;

            if (events.TryGetValue(eventType, out currentEvent))
            {
                currentEvent.AddListener(listener);
            }
            else
            {
                currentEvent = new UnityEvent();
                currentEvent.AddListener(listener);
                events.Add(eventType, currentEvent);
            }
        }

        public static void Unsubscribe(AppEvents eventType, UnityAction listener)
        {
            UnityEvent currentEvent;

            if (events.TryGetValue(eventType, out currentEvent))
            {
                currentEvent.RemoveListener(listener);
            }
        }

        public static void Execute(AppEvents eventType)
        {
            UnityEvent eventToExecute;
            if (events.TryGetValue(eventType, out eventToExecute))
            {
                eventToExecute.Invoke();
            }
        }

        public static async void Execute(AppEvents eventType, float invokeTime)
        {
            UnityEvent eventToExecute;
            if (events.TryGetValue(eventType, out eventToExecute))
            {
                await Task.Delay(TimeSpan.FromSeconds(invokeTime));
                eventToExecute.Invoke();
            }
        }
    }
}

