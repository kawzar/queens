using UnityEngine;

namespace Kawzar.Queens.Model.Events
{
    [CreateAssetMenu]
    public class SwipeEventArgs : ScriptableObject
    {
        public float EconomyDelta;
        public float PopularityDelta;
        public float MusicDelta;
    }
}