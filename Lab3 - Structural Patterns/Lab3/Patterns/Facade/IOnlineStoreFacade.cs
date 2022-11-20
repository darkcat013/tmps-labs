using Lab3.Patterns.Decorator;

namespace Lab3.Patterns.Facade
{
    public interface IOnlineStoreFacade
    {
        List<IItem> SearchItem(string query);
        void ShowAllItems();
        void PrintAllStores();
    }
}
