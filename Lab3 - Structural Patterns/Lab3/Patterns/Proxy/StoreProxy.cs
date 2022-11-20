using Lab3.Patterns.Decorator;

namespace Lab3.Patterns.Proxy
{
    public class StoreProxy : IStore
    {
        private readonly IStore _store;

        public StoreProxy(IStore store)
        {
            _store = store;
        }

        public void AddItem(IItem item, int amount)
        {
            _store.AddItem(item, amount);
        }

        public void AddToItem(int id, int amount)
        {
            if(_store.GetItems().Count < id)
            {
                Console.WriteLine($"Item with id {id} does not exist");
                return;
            }
            _store.AddToItem(id, amount);
        }

        public string GetFullInfo()
        {
            return _store.GetFullInfo();
        }

        public IItem GetItem(int id)
        {
            if (_store.GetItems().Count < id)
            {
                Console.WriteLine($"Item with id {id} does not exist");
                return null;
            }
            return _store.GetItem(id);
        }

        public List<(IItem Item, int Amount)> GetItems()
        {
            if( _store.GetItems().Count == 0)
            {
                Console.WriteLine("This store has no items");
            }
            
            return _store.GetItems();
        }

        public string GetShortInfo()
        {
            return _store.GetShortInfo();
        }

        public void RemoveFromItem(int id, int amount)
        {
            if (_store.GetItems().Count < id)
            {
                Console.WriteLine($"Item with id {id} does not exist");
                return;
            }
            _store.RemoveFromItem(id, amount);
        }

        public void RemoveItem(int id)
        {
            if (_store.GetItems().Count < id)
            {
                Console.WriteLine($"Item with id {id} does not exist");
                return;
            }
            _store.RemoveItem(id);
        }
    }
}
