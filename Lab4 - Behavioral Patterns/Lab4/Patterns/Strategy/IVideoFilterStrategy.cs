using Lab4.Domain;
using Lab4.Patterns.TemplateMethod;

namespace Lab4.Patterns.Strategy
{
    public interface IVideoFilterStrategy
    {
        List<Video> GetVideos(Channel channel);
    }
}
