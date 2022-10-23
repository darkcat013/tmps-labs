using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    class VideoGameStore
    {
        public string Name { get; }
        public int Year { get; }
        public float Price { get; }
        public VideoGameStore(string name, int year, int price)
        {
            Name = name;
            Year = year;
            Price = price;
        }
        public void SaveCustomerOrder() { }
        public void GetCustomerOrder() { }
        public void RemoveCustomerOrder() { }
        public void AddVideoGame(VideoGameStore v) { }
        public void DeleteVideoGame(VideoGameStore v) { }
        public void UpdateVideoGame(VideoGameStore v) { }
    }
}
