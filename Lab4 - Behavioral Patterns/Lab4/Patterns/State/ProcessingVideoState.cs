namespace Lab4.Patterns.State
{
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
}
