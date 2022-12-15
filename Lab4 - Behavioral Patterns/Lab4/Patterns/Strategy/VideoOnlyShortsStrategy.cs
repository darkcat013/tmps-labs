using Lab4.Domain;
using Lab4.Patterns.TemplateMethod;

namespace Lab4.Patterns.Strategy
{
    public class VideoOnlyShortsStrategy : IVideoFilterStrategy
    {
        public List<Video> GetVideos(Channel channel)
        {
            return channel.Videos.Where(v => v.GetType() == typeof(ShortVideo)).ToList();
        }

        public override string ToString() => "Only shorts";
    }
}
