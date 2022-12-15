# Behavioral Design Patterns

## Author: Viorel Noroc

----

## Objectives

* Study and understand the Behavioral Design Patterns.
* Choose a specific domain;
* Implement at least 3 BDPs for the specific domain;

## Used Design Patterns

* Observer
* State
* Template Method
* Strategy
* Command

## Implementation

In this laboratory work a simulation of a video streaming channel was implemented.

### Observer

The implementation of Observer pattern in this project is represented by users subscribing to the channel.

```cs
public interface ISubscriber
    {
        void Update(string notification);
    }
```

```cs
public class User : ISubscriber
    {
        public string Name { get; set; }
        public void Update(string notification)
        {
            Console.WriteLine($"{Name}! \n {notification}");
        }
    }
```

### State

The implementation of State pattern in this project is representeed by each video of the channel having a state: Processing, Private, Public.

```cs
public interface IVideoState
    {
        void Play();
    }
```

```cs
public class PrivateVideoState : IVideoState
    {
        public void Play()
        {
            Console.WriteLine("You don't have access to this video.");
        }

        public override string ToString()
        {
            return "Private";
        }
    }
```

```cs
public class ProcessingVideoState : IVideoState
    {
        public void Play()
        {
            Console.WriteLine("Video is still processing, try again later.");
        }

        public override string ToString()
        {
            return "Processing";
        }
    }
```

```cs
public class PublicVideoState : IVideoState
    {
        public void Play()
        {
            Console.WriteLine("Playing video...");
        }

        public override string ToString()
        {
            return "Public";
        }
    }
```

### Template Method

The implementation of Template Method pattern in this project generalizez all the types of the videos that the platform can have, in this case it's the Normal videos and Shorts video(stories). All videos can be played but only normal videos can be rewinded and normal videos are Horizontal while stories are Vertical.

```cs
public abstract class Video
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public IVideoState State { get; set; }
        public string Orientation { get; set; }
        public int Views { get; set; }
        public void Play ()
        {
            Console.Write($"{Name}: ");
            State.Play();
        }
        public void ChangeState(IVideoState state)
        {
            State = state;
        }
        public abstract void SetTime(int minute, int second);
    }
```

```cs
public class NormalVideo : Video
    {
        public NormalVideo()
        {
            Orientation = "Horizontal";
            ChangeState(new ProcessingVideoState());
        }

        public override void SetTime(int minute, int second)
        {
            Console.WriteLine($"Video rewinded to {minute}:{second}");
        }
    }
```

```cs
public class ShortVideo : Video
    {
        public ShortVideo()
        {
            Orientation = "Vertical";
            ChangeState(new ProcessingVideoState());
        }

        public override void SetTime(int minute, int second)
        {
            Console.WriteLine("Cannot rewind Short video");
        }
    }
```

### Strategy

The implementation of Strategy pattern in this project provides some sorting/filtering options for getting videos from channel.

```cs
public interface IVideoFilterStrategy
    {
        List<Video> GetVideos(Channel channel);
    }
```

```cs
public class VideoAlphabeticOrderStrategy : IVideoFilterStrategy
    {
        public List<Video> GetVideos(Channel channel)
        {
            return channel.Videos.OrderBy(v => v.Name).ToList();
        }

        public override string ToString() => "Alphabetic order";
    }
```

```cs
public class VideoMostViewedStrategy : IVideoFilterStrategy
    {
        public List<Video> GetVideos(Channel channel)
        {
            return channel.Videos.OrderByDescending(v => v.Views).ToList();
        }

        public override string ToString() => "Most viewed";
    }
```

```cs
public class VideoOnlyShortsStrategy : IVideoFilterStrategy
    {
        public List<Video> GetVideos(Channel channel)
        {
            return channel.Videos.Where(v => v.GetType() == typeof(ShortVideo)).ToList();
        }

        public override string ToString() => "Only shorts";
    }
```

### Command

The implementation of Command pattern is straightforward, it sends commands to the channel mostly and they also can be put in a list and executed in order or later.

```cs
public abstract class Command
    {
        public bool IsExecuted { get; set; }

        public abstract void Execute();
    }
```

```cs
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
```

```cs
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
```

```cs
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
```

## Conclusions

This laboratory work was an interesting and useful one because I solidified my already existing knowledge on Behavioral Design Patterns and I got to implement some patterns I did not know about. This laboratory was easier than the previous ones purely because there are more Behavioral design patterns so it was easier to find a use case.

The expected output of Program.cs

```text
User 1!
 New video added: Short video 1
User 2!
 New video added: Short video 1
User 1!
 New video added: Short video 2

Show all videos:
Normal video 1
 Views: 12
 Status: Processing
Short video 1
 Views: 0
 Status: Processing
Short video 2
 Views: 2
 Status: Processing

Showing videos by: Most viewed
Normal video 1
 Views: 12
 Status: Processing
Short video 2
 Views: 2
 Status: Processing
Short video 1
 Views: 0
 Status: Public

Showing videos by: Only shorts
Short video 1
 Views: 0
 Status: Public
Short video 2
 Views: 2
 Status: Private
Normal video 1: Video is still processing, try again later.
Short video 1: Playing video...
Short video 2: You don't have access to this video.
```
