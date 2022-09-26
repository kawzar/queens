using System.Collections.Generic;
using UnityEngine;

namespace Kawzar.Queens.Model.Events
{
    [CreateAssetMenu]
    public class SwipeEvent : GameEvent
    {
        [SerializeField] public SwipeEventArgs args;
        
        private List<ISwipeEventListener> _presenters = new List<ISwipeEventListener>();

        public override void Raise()
        {
            for (int i = _presenters.Count - 1; i >= 0; i--)
            {
                _presenters[i].OnEventRaised(args);
            }
        }
        
        public void RegisterListener(ISwipeEventListener listener)
        {
            _presenters.Add(listener);
        }

        public void UnregisterListener(ISwipeEventListener listener)
        {
            _presenters.Remove(listener);
        }
    }
}