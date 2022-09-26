using Kawzar.Queens.Model.Events;
using Kawzar.Queens.View;
using Model;
using UniRx;

namespace Kawzar.Queens.Presenter
{
    public class StatsPresenter : ISwipeEventListener
    {
        public readonly FloatReactiveProperty Economy;
        public readonly FloatReactiveProperty Popularity;
        public readonly FloatReactiveProperty Music;

        private StatsView _view;

        public StatsPresenter(StatsModel model, StatsView view)
        {
            foreach (var evt in model.swipeEvents)
            {
                evt.RegisterListener(this);
            }
            
            Economy = new FloatReactiveProperty(model.maxEconomy /2 );
            Popularity = new FloatReactiveProperty(model.maxPopularity / 2);
            Music = new FloatReactiveProperty(model.maxMusic / 2);

            _view = view;

            Economy.Subscribe(onNext: f => _view.SetEconomyFillAmount(f / model.maxEconomy));
            Popularity.Subscribe(onNext: f => _view.SetPopularityFillAmount(f / model.maxPopularity));
            Music.Subscribe(onNext: f => _view.SetMusicFillAmount(f / model.maxMusic));
        }

        public void OnEventRaised(SwipeEventArgs args)
        {
            Economy.Value += args.EconomyDelta;
            Popularity.Value += args.PopularityDelta;
            Music.Value += args.MusicDelta;
        }
    }
}