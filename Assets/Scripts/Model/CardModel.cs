using Kawzar.Queens.Model.Events;
using UnityEngine;

namespace Kawzar.Queens.Model
{
    [CreateAssetMenu(menuName = "Create CardModel", fileName = "CardModel", order = 0)]
    public class CardModel : ScriptableObject
    {
        public Sprite sprite;
        public string text;
        public SwipeEvent swipeLeftEvent;
        public SwipeEvent swipeRightEvent;
    }
}