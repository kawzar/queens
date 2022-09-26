using UnityEngine;
using UnityEngine.UI;

namespace Kawzar.Queens.View
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private Image economyImage;
        [SerializeField] private Image popularityImage;
        [SerializeField] private Image musicImage;

        public void SetEconomyFillAmount(float ratio)
        {
            economyImage.fillAmount = ratio;
        }
        
        public void SetPopularityFillAmount(float ratio)
        {
            popularityImage.fillAmount = ratio;
        }
        
        public void SetMusicFillAmount(float ratio)
        {
            musicImage.fillAmount = ratio;
        }
    }
}