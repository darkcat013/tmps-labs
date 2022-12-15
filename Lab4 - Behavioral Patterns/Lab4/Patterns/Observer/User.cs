using Lab4.Patterns.Observer;

namespace Lab4.Domain
{
    public class User : ISubscriber
    {
        public string Name { get; set; }
        public void Update(string notification)
        {
            Console.WriteLine($"{Name}! \n {notification}");
        }
    }
}
