using System;
using UnityEngine;

namespace Kawzar.Queens.Model.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public Action Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}