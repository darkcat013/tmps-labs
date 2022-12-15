using Lab4.Domain;
using Lab4.Patterns.State;
using Lab4.Patterns.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Patterns.Command
{
    public class ChangeVideoStateCommand : Command
    {
        private Channel _channel;
        private Video _video;
        private IVideoState _state;
        public ChangeVideoStateCommand(Channel channel, Video video, IVideoState state) {
            _channel= channel;
            _video= video;
            _state= state;
        }
        public override void Execute()
        {
            _channel.GetVideo(_video).ChangeState(_state);
            IsExecuted= true;
        }
    }
}
