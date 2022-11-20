namespace Lab3.Patterns.Decorator
{
    public class ProdDateItemDecorator : ItemDecorator
    {
        public DateTime ProductionDate { get; private set; }

        public ProdDateItemDecorator(IItem item, DateTime productionDate) : base(item)
        {
            ProductionDate = productionDate;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()} Production date: {ProductionDate}\n";
        }
    }
}
