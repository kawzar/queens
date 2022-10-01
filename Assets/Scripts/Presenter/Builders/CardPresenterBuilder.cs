using System.Collections;
using System.Collections.Generic;
using Kawzar.Queens.Model;
using Kawzar.Queens.View;
using UnityEngine;

namespace Kawzar.Queens.Presenter.Builders
{
    public static class CardPresenterBuilder
    {
        public static CardPresenter BuildCardPresenter(CardView view, CardModel model)
        {
            return new CardPresenter(model, view);
        }
    }
}