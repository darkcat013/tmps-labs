using Lab3.Patterns.Composite;
using Lab3.Patterns.Decorator;

namespace Lab3.Patterns.Proxy
{
    public interface IStore : IOwnership
    {
        public IItem GetItem(int id);
        public List<(IItem Item, int Amount)> GetItems();
        public void AddItem(IItem item, int amount);
        public void AddToItem(int id, int amount);
        public void RemoveFromItem(int id, int amount);
        public void RemoveItem(int id);
    }
}
