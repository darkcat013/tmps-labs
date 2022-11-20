namespace Lab3.Patterns.Decorator
{
    public class ExpiringItemDecorator : ItemDecorator
    {
        public DateTime ExpirationDate { get; private set; }

        public ExpiringItemDecorator(IItem item, DateTime expirationDate) : base(item)
        {
            ExpirationDate = expirationDate;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()} Expiration date: {ExpirationDate}\n";
        }
    }
}
