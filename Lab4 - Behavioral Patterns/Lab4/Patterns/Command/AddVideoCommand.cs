using Lab4.Domain;
using Lab4.Patterns.TemplateMethod;

namespace Lab4.Patterns.Command
{
    public class AddVideoCommand : Command
    {
        private Channel _channel;
        private Video _video;
        public AddVideoCommand(Channel channel, Video video) { 
            _channel = channel;
            _video = video;
        }
        public override void Execute()
        {
            _channel.AddVideo(_video);
            IsExecuted = true;
        }
    }
}
