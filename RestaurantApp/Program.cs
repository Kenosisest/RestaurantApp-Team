using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Hello SIT.1/1");
            Console.WriteLine("Weak 2");
            List<Restaurant> restaurants = new List<Restaurant>
            {
            new Restaurant(1, "Quanjude Roast Duck", "Beijing Cuisine", 4.5),
            new Restaurant(2, "Donglaishun Hot Pot", "Hot Pot", 4.6),
            new Restaurant(3, "Din Tai Fung", "Taiwanese Cuisine", 4.7),
            new Restaurant(4, "Huguosi Snacks", "Snacks" ,4.2),
            new Restaurant(5, "Haidilao Hot", "Pot Hot Pot", 4.8)
            };
           
            foreach (Restaurant res in restaurants)
            {
                Console.WriteLine($"ID: {res.Id} | ร้าน: {res.Name} | ประเภท: {res.Type} | คะแนน: {res.Rating}");
            }


        }
    }
    public class AddRestaurant
    {

    }
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
        public Restaurant(int id, string name, string type, double rate)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Rating = rate;
        }
    }
}
