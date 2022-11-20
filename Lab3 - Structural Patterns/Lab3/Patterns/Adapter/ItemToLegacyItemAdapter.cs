using Lab3.Patterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Patterns.Adapter
{
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
}
