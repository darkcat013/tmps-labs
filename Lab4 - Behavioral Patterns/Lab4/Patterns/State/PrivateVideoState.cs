namespace Lab4.Patterns.State
{
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
}
