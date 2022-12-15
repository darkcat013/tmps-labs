using Lab4.Domain;
using Lab4.Patterns.Command;
using Lab4.Patterns.State;
using Lab4.Patterns.Strategy;
using Lab4.Patterns.TemplateMethod;

namespace Lab4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new();

            var normalVideo = new NormalVideo()
            {
                Url = "https://youtu.be/NF-OmFNFsaw",
                Name = "Normal video 1",
                Views = 12
            };

            var shortVideo1 = new ShortVideo()
            {
                Url = "https://youtu.be/kyr5TTA3X0g",
                Name = "Short video 1",
                Views = 0
            };

            var shortVideo2 = new ShortVideo()
            {
                Url = "https://youtu.be/hUdB232fIXM",
                Name = "Short video 2",
                Views = 2
            };
            var addVideoCommand = new AddVideoCommand(channel, normalVideo);
            addVideoCommand.Execute();
            if(!addVideoCommand.IsExecuted)
            {
                throw new Exception("Video not uploaded");
            }

            User user1 = new()
            {
                Name = "User 1"
            };

            User user2 = new()
            {
                Name = "User 2"
            };

            User unsubscribed = new()
            {
                Name = "User 3"
            };

            channel.Subscribe(user1);
            channel.Subscribe(user2);

            addVideoCommand = new AddVideoCommand(channel, shortVideo1);
            addVideoCommand.Execute();
            if (!addVideoCommand.IsExecuted)
            {
                throw new Exception("Video not uploaded");
            }

            channel.Unsubscribe(user2);

            List<Command> commandList = new()
            {
                
                new AddVideoCommand(channel, shortVideo2),
                new DisplayVideosCommand(channel),
                new ChangeVideoStateCommand(channel, shortVideo1, new PublicVideoState()),
                new DisplayVideosCommand(channel, new VideoMostViewedStrategy()),
                new ChangeVideoStateCommand(channel, shortVideo2, new PrivateVideoState()),
                new DisplayVideosCommand(channel, new VideoOnlyShortsStrategy())
            };

            foreach(var command in commandList)
            {
                command.Execute();
                if(!command.IsExecuted)
                {
                    throw new Exception("Command not executed");
                }
            }

            foreach(var video in channel.Videos)
            {
                video.Play();
            }
        }
    }
}