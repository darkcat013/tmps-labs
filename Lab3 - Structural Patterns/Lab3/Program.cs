
using Lab3.Patterns.Adapter;
using Lab3.Patterns.Composite;
using Lab3.Patterns.Decorator;
using Lab3.Patterns.Facade;

namespace Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Store store1 = new Store
            {
                Address = "Dacia 69",
                Name = "Airport linella",
                Items = GetItems()
            };

            Store store2 = new Store
            {
                Address = "bd. Moscova",
                Name = "Rascani Linella",
                Items = GetItems()
            };

            store2.RemoveItem(1);
            store2.AddItem(GetAdaptedLegacyItem(), 20);
            var fidesco = new Company
            {
                Name = "Fidesco",
                Address = "Fidesco address"
            };

            var company = new Company { 
                Name = "Linella",
                Address = "Linella address",
                Ownerships = new()
                {
                    store1,
                    store2,
                    fidesco
                }
            };

            Console.WriteLine(company.GetFullInfo());

            var onlineStore = new OnlineStoreFacade(company);
            onlineStore.PrintAllStores();
            onlineStore.ShowAllItems();
            var foundItems = onlineStore.SearchItem("honey");
        }

        static List<(IItem Item, int Amount)> GetItems()
        {
            Item milk = new Item("Cow milk");
            ItemDecorator milkDecorator = new ExpiringItemDecorator(milk, DateTime.Now.AddDays(5));
            milkDecorator = new DetailedItemDecorator(milkDecorator, "Good cow milk");

            Item honey = new Item("Bee honey");
            ItemDecorator honeyDecorator = new ProdDateItemDecorator(honey, DateTime.Now.AddDays(-100));
            honeyDecorator = new DetailedItemDecorator(honeyDecorator, "Monastery honey");

            return new()
            {
                new()
                {
                    Item = milkDecorator,
                    Amount = 10
                },
                new()
                {
                    Item = honeyDecorator,
                    Amount = 5
                }
            };
        }

        static IItem GetAdaptedLegacyItem()
        {
            var item = new LegacyItem
            {
                Name = "PopCorn",
                Description = "good popcorn great popcorn",
                DateProduced = DateTime.Now,
                DateExpired = DateTime.Now.AddDays(10)
            };

            var itemAdapter = new ItemToLegacyItemAdapter(item);
            return itemAdapter;
        }
    }
}