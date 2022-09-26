using Kawzar.Queens.Model;
using Kawzar.Queens.View;

namespace Kawzar.Queens.Presenter
{
   public class CardPresenter : IPresenter
   {
      private CardView _view;
      private CardModel _model;

      public CardPresenter(CardModel model, CardView view)
      {
         _model = model;
         _view = view;
         
         _view.Initialize(_model.sprite, _model.text);
         _view.SwipeLeft += () => { _model.swipeLeftEvent.Raise(); };
         _view.SwipeRight += () => { _model.swipeRightEvent.Raise();};
      }
   }
}