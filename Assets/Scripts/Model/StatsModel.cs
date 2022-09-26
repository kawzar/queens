using Kawzar.Queens.Model.Events;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(menuName = "Create StatsModel", fileName = "StatsModel", order = 0)]
    public class StatsModel : ScriptableObject
    {
        public int minEconomy;
        public int maxEconomy;
        public int minPopularity;
        public int maxPopularity;
        public int minMusic;
        public int maxMusic;
        
        public SwipeEvent[] swipeEvents;
    }
}
