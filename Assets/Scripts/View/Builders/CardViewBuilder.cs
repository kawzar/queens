using Kawzar.Queens.Global;
using Kawzar.Queens.Model;
using UnityEngine;

namespace Kawzar.Queens.View.Builders
{
    public static class CardViewBuilder
    {
        public static CardView BuildCardView(CardModel model)
        {
            return UnityEngine.GameObject.Instantiate(SceneContext.Instance.CardViewPrefab, SceneContext.Instance.MainCanvas.transform);
        }
    }
}