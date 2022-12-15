using Lab4.Patterns.Observer;
using Lab4.Patterns.TemplateMethod;

namespace Lab4.Domain
{
    public class Channel
    {
        public List<Video> Videos { get; set; }
        public List<ISubscriber> Subscribers { get; set; }
        public Channel() {
            Videos = new();
            Subscribers = new();
        }
        public void AddVideo(Video video)
        {
            Videos.Add(video);
            NotifySubscribers($"New video added: {video.Name}");
        }

        public Video GetVideo(Video video)
        {
            return Videos.First(v => v.Url.Equals(video.Url));
        }

        public void NotifySubscribers(string notification)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Update(notification);
            }
        }

        public void Subscribe(User user)
        {
            Subscribers.Add(user);
        }

        public void Unsubscribe(User user)
        {
            Subscribers.Remove(user);
        }
    }
}
