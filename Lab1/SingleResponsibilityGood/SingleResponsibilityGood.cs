using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    class VideoGame
    {
        public string Name { get; }
        public int Year { get; }
        public float Price { get; }
        public VideoGame(string name, int year, int price)
        {
            Name = name;
            Year = year;
            Price = price;
        }
    }
    class VideoGameCustomerService 
    {
        public void SaveCustomerOrder() { }
        public void GetCustomerOrder() { }
        public void RemoveCustomerOrder() { }
    }

    class VideoGameDb
    {
        public void AddVideoGame(VideoGame v) { }
        public void DeleteVideoGame(VideoGame v) { }
        public void UpdateVideoGame(VideoGame v) { }
    }
}
