namespace Lab4.Patterns.State
{
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
}
