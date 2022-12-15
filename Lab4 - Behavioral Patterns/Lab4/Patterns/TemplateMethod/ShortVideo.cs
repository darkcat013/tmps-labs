using Lab4.Patterns.State;

namespace Lab4.Patterns.TemplateMethod
{
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
}
