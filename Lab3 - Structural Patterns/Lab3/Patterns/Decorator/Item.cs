namespace Lab3.Patterns.Decorator
{
    public class Item : IItem
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }

        public string GetInfo()
        {
            return $"Item name: {Name}\n";
        }
    }
}
