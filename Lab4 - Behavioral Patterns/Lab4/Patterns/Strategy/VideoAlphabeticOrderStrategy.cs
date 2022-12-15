using Lab4.Domain;
using Lab4.Patterns.TemplateMethod;

namespace Lab4.Patterns.Strategy
{
    public class VideoAlphabeticOrderStrategy : IVideoFilterStrategy
    {
        public List<Video> GetVideos(Channel channel)
        {
            return channel.Videos.OrderBy(v => v.Name).ToList();
        }

        public override string ToString() => "Alphabetic order";
    }
}
