namespace Kawzar.Queens.Model.Events
{
    public interface ISwipeEventListener
    {
        void OnEventRaised(SwipeEventArgs args);
    }
}