using Lab4.Patterns.State;

namespace Lab4.Patterns.TemplateMethod
{
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
}
