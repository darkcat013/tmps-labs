using Lab3.Patterns.Composite;
using Lab3.Patterns.Decorator;
using Lab3.Patterns.Proxy;

namespace Lab3.Patterns.Facade
{
    public class OnlineStoreFacade :IOnlineStoreFacade
    {
        private readonly List<StoreProxy> _stores;

        public OnlineStoreFacade(Company company)
        {
            _stores = new();
            
            var s = company.Ownerships.Where(store => store.GetType() == typeof(Store)).Cast<Store>().ToList();
            foreach (var store in s)
            {
                _stores.Add(new(store));
            }
        }

        public List<IItem> SearchItem(string query)
        {
            List<IItem> result = new();
            string resultString = "Found items: \n ";
            foreach (var store in _stores)
            {
                foreach(var item in store.GetItems())
                {
                    if(item.Item.GetInfo().Contains(query))
                    {
                        result.Add(item.Item);
                        resultString += item.Item.GetInfo();
                    }
                }
            }
            Console.WriteLine(resultString);
            return result;
        }

        public void ShowAllItems()
        {
            string result = "All items: \n";
            foreach (var store in _stores)
            {
                result += store.GetFullInfo() + "\n\n";
            }
            Console.WriteLine(result);
        }

        public void PrintAllStores()
        {
            string result = "All stores: \n";
            foreach (var store in _stores)
            {
                result += store.GetShortInfo() + "\n\n";
            }
            Console.WriteLine(result);
        }
    }
}
