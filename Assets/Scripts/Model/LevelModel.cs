using System.Collections.Generic;
using Kawzar.Queens.Model.Events;
using UnityEngine;

namespace Kawzar.Queens.Model
{
    [CreateAssetMenu]
    public class LevelModel : ScriptableObject
    {
        public SwipeEvent[] swipeEvents;

        private Stack<CardModel> cardStack;
    }
}

