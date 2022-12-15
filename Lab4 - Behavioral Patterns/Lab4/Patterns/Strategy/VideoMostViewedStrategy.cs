using Lab4.Domain;
using Lab4.Patterns.TemplateMethod;

namespace Lab4.Patterns.Strategy
{
    public class VideoMostViewedStrategy : IVideoFilterStrategy
    {
        public List<Video> GetVideos(Channel channel)
        {
            return channel.Videos.OrderByDescending(v => v.Views).ToList();
        }

        public override string ToString() => "Most viewed";
    }
}
