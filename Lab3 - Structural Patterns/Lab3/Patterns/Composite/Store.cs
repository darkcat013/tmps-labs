using Lab3.Patterns.Decorator;
using Lab3.Patterns.Proxy;

namespace Lab3.Patterns.Composite
{
    public class Store : IOwnership, IStore
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public List<(IItem Item, int Amount)> Items { get; init; }
        public string GetFullInfo()
        {
            string itemInfos = "";
            for(int i = 0; i < Items.Count; i++)
            {
                itemInfos += $"{i}: Amount: {Items[i].Amount}\n {Items[i].Item.GetInfo()}\n";
            }
            return $"{nameof(Store)} {Name} at address {Address} has items : \n\n{itemInfos}";
        }

        public string GetShortInfo()
        {
            return $"{nameof(Store)} name: {Name} \n Address: {Address}";
        }

        public IItem GetItem(int id)
        {
            return Items[id].Item;
        }

        public List<(IItem Item, int Amount)> GetItems()
        {
            return Items;
        }

        public void AddItem(IItem item, int amount)
        {
            Items.Add((item, amount));
        }

        public void AddToItem(int id, int amount)
        {
            var newAmount = Items[id].Amount + amount;

            Items[id] = new(Items[id].Item, newAmount);
        }
        public void RemoveFromItem(int id, int amount)
        {
            var newAmount = Items[id].Amount - amount;

            Items[id] = new(Items[id].Item, newAmount);
        }
        public void RemoveItem(int id)
        {
            Items.RemoveAt(id);
        }
    }
}
