using Kawzar.Queens.Global;
using Kawzar.Queens.Model;
using Kawzar.Queens.Model.Events;
using Kawzar.Queens.Presenter;
using Kawzar.Queens.Presenter.Builders;
using Kawzar.Queens.View.Builders;

public class LevelPresenter : IPresenter, ISwipeEventListener
{
    private LevelView _view;
    private LevelModel _model;

    public LevelPresenter(LevelView view, LevelModel model, CardService cardService)
    {
        _view = view;
        _model = model;
        
        foreach (var evt in model.swipeEvents)
        {
            evt.RegisterListener(this);
        }
        
        CreateAndShowNewCard();
    }

    public void OnEventRaised(SwipeEventArgs args)
    {
       CreateAndShowNewCard();
    }

    private void CreateAndShowNewCard()
    {
        var cardModel = SceneContext.Instance.CardService.GetRandomCardModel();
        var view = CardViewBuilder.BuildCardView(cardModel);
        var presenter = CardPresenterBuilder.BuildCardPresenter(view, cardModel);
    }
}
