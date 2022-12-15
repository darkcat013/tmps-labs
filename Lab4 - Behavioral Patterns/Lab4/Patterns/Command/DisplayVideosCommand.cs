using Lab4.Domain;
using Lab4.Patterns.Strategy;
using Lab4.Patterns.TemplateMethod;

namespace Lab4.Patterns.Command
{
    public class DisplayVideosCommand : Command
    {
        private Channel _channel;
        private IVideoFilterStrategy _filterStrategy;

        public DisplayVideosCommand(Channel channel, IVideoFilterStrategy filterStrategy = null)
        {
            _channel= channel;
            _filterStrategy= filterStrategy;
        }
        public override void Execute()
        {
            List<Video> videos;
            if (_filterStrategy == null)
            {
                videos = _channel.Videos;
                Console.WriteLine("\nShow all videos:");
            }
            else
            {
                videos = _filterStrategy.GetVideos( _channel );
                Console.WriteLine($"\nShowing videos by: {_filterStrategy}" );
            }
            foreach ( Video video in videos )
            {
                Console.WriteLine($"{video.Name}\n Views: {video.Views}\n Status: {video.State}");
            }
            IsExecuted = true;
        }
    }
}
