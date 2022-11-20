namespace Lab3.Patterns.Decorator
{
    public abstract class ItemDecorator : IItem
    {
        private IItem _item;
        
        public ItemDecorator(IItem item)
        {
            _item = item;
        }

        public virtual string GetInfo()
        {
            return _item.GetInfo();
        }
    }
}
