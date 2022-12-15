using Lab4.Patterns.State;

namespace Lab4.Patterns.TemplateMethod
{
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
}
