# Structural Design Patterns

## Author: Viorel Noroc

----

## Objectives

* Study and understand the Structural Design Patterns.
* Choose a specific domain;
* Implement at least 3 SDPs for the specific domain;

## Used Design Patterns

* Adapter
* Composite
* Decorator
* Facade
* Proxy

## Implementation

### Composite

The implementation of Composite pattern in this project consists of companies that can own companies or stores.

```cs
public interface IOwnership
    {
        
        string GetFullInfo();
        string GetShortInfo();
    }
```

```cs
public class Company : IOwnership
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public List<IOwnership> Ownerships { get; init; }
        ...
    }
```

```cs
public class Store : IOwnership, IStore
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public List<(IItem Item, int Amount)> Items { get; init; }
        ...
    }
```

### Decorator

The implementation of Decorator pattern in this project allows to decorate store items with information.

```cs
public class Item : IItem
    {
        public string Name { get; set; }
        ...
    }
```

```cs
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
```

```cs
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
```

```cs
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
```

### Proxy

The implementation of Proxy pattern in this project checks if the items are really in the store or not.

```cs
public class StoreProxy : IStore
    {
        private readonly IStore _store;

        public StoreProxy(IStore store)
        {
            _store = store;
        }
    ...
    public IItem GetItem(int id)
        {
            if (_store.GetItems().Count < id)
            {
                Console.WriteLine($"Item with id {id} does not exist");
                return null;
            }
            return _store.GetItem(id);
        }
    ...
    public void RemoveItem(int id)
        {
            if (_store.GetItems().Count < id)
            {
                Console.WriteLine($"Item with id {id} does not exist");
                return;
            }
            _store.RemoveItem(id);
        }
    ...
    }
```

### Facade

The implementation of Facade pattern in this project emulates an online store.

```cs
public interface IOnlineStoreFacade
    {
        List<IItem> SearchItem(string query);
        void ShowAllItems();
        void PrintAllStores();
    }
```

```cs
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
    ...
    }
```

### Adapter

The implementation of Adapter pattern simulates the fact that there were LegactItem objects that need to be used as the new Item that allows decorators.

```cs
public class LegacyItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateProduced { get; set; }
        public DateTime? DateExpired { get; set; }
    }
```

```cs
public class ItemToLegacyItemAdapter : IItem
    {
        private readonly LegacyItem _item;

        public ItemToLegacyItemAdapter(LegacyItem item)
        {
            _item = item;
        }

        public string GetInfo()
        {
            string name = !string.IsNullOrEmpty(_item.Name) ? $"Item Name: {_item.Name}\n": string.Empty;
            string description = !string.IsNullOrEmpty(_item.Description) ? $" Details: {_item.Description}\n" : string.Empty;
            string dateProduced = _item.DateProduced.HasValue ? $" Production date: {_item.DateProduced.Value}\n" : string.Empty;
            string dateExpired = _item.DateExpired.HasValue ? $" Expiration date: {_item.DateExpired.Value}\n" : string.Empty;

            return name + description + dateProduced + dateExpired;
        }
    }
```

## Conclusions

This laboratory work was an interesting and useful one because I solidified my already existing knowledge on Structural Design Patterns and I got to implement some patterns I did not know about. The only thing that I did not like about this laboratory work is that I spent more time thinking about a use case for these patterns than to actually write the code and the report.

The expected output of Program.cs
```text
Company Linella at address Linella address owns :
 Store name: Airport linella
 Address: Dacia 69
Store name: Rascani Linella
 Address: bd. Moscova
Company name: Fidesco
 Address: Fidesco address

All stores:
Store name: Airport linella
 Address: Dacia 69

Store name: Rascani Linella
 Address: bd. Moscova


All items:
Store Airport linella at address Dacia 69 has items :

0: Amount: 10
 Item name: Cow milk
 Expiration date: 25/11/2022 11:14:51 PM
 Details: Good cow milk


1: Amount: 5
 Item name: Bee honey
 Production date: 12/08/2022 11:14:51 PM
 Details: Monastery honey




Store Rascani Linella at address bd. Moscova has items :

0: Amount: 10
 Item name: Cow milk
 Expiration date: 25/11/2022 11:14:51 PM
 Details: Good cow milk


1: Amount: 20
 Item Name: PopCorn
 Details: good popcorn great popcorn
 Production date: 20/11/2022 11:14:51 PM
 Expiration date: 30/11/2022 11:14:51 PM




Found items:
 Item name: Bee honey
 Production date: 12/08/2022 11:14:51 PM
 Details: Monastery honey
```