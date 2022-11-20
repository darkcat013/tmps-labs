namespace Lab3.Patterns.Decorator
{
    public class DetailedItemDecorator : ItemDecorator
    {

        public string Details { get; private set; }
        public DetailedItemDecorator(IItem item, string details) : base(item)
        {
            Details = details;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} Details: {Details}\n\n";
        }
    }
}
