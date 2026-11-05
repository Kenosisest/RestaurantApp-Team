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
            Summary summary = new Summary();

            summary.ShowHighestRating(restaurants);
            summary.ShowLowestRating(restaurants);

            Console.ReadLine();
            AddRestaurant(restaurants);
            Good_Rating goodRating = new Good_Rating();

            goodRating.ShowGoodRating(restaurants);

            Console.WriteLine("\n=== รายการร้านค้าทั้งหมด ===");
            foreach (Restaurant res in restaurants)
            {
                Console.WriteLine($"ID: {res.Id} | ร้าน: {res.Name} | ประเภท: {res.Type} | คะแนน: {res.Rating}");
            }
            Console.Write("\n กรอกชื่อร้านที่ต้องการค้นหา (พิมพ์บางส่วนได้): ");
            string keyword = Console.ReadLine();

           
            SearchRestaurantByName(restaurants, keyword);

        }
        public static void SearchRestaurantByName(List<Restaurant> restaurants, string keyword)
        {
            var results = restaurants
                .Where(r => r.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();

            Console.WriteLine($"\n================ ผลการค้นหา \"{keyword}\" ================");

            if (results.Count > 0)
            {
                foreach (Restaurant res in results)
                {
                    Console.WriteLine($"ID: {res.Id} | ร้าน: {res.Name} | ประเภท: {res.Type} | คะแนน: {res.Rating}");
                }
            }
            else
            {
                Console.WriteLine("ไม่พบร้านอาหารที่คุณค้นหา");
            }
            Console.WriteLine("==================================================");
        }
    }

        }
        public static void AddRestaurant(List<Restaurant> list)
        {
            Console.WriteLine("\n--- เพิ่มข้อมูลร้านอาหารใหม่ ---");

            int id = list.Count + 1;

            Console.Write("กรอกชื่อร้าน: ");
            string name = Console.ReadLine();

            Console.Write("กรอกประเภทร้าน: ");
            string type = Console.ReadLine();

            Console.Write("กรอกคะแนนร้าน (เช่น 2.5): ");
            double rating;
            
            while (!double.TryParse(Console.ReadLine(), out rating))
            {
                Console.Write("กรอกข้อมูลไม่ถูกต้อง กรุณากรอกคะแนนเป็นตัวเลข: ");
            }

            list.Add(new Restaurant(id, name, type, rating));
            Console.WriteLine("เพิ่มข้อมูลร้านสำเร็จ!");
        }
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
    public class Summary
    {
        public void ShowHighestRating(List<Restaurant> restaurants)
        {
            var highest = restaurants.OrderByDescending(r => r.Rating).First();

            Console.WriteLine("\n=== คะแนนสูงสุด ===");
            Console.WriteLine($"ร้าน: {highest.Name}");
            Console.WriteLine($"คะแนน: {highest.Rating}");
        }

        public void ShowLowestRating(List<Restaurant> restaurants)
        {
            var lowest = restaurants.OrderBy(r => r.Rating).First();

            Console.WriteLine("\n=== คะแนนต่ำสุด ===");
            Console.WriteLine($"ร้าน: {lowest.Name}");
            Console.WriteLine($"คะแนน: {lowest.Rating}");
        }
    }

    public class Good_Rating
    {
        public void ShowGoodRating(List<Restaurant> restaurants)
        {
            foreach (Restaurant res in restaurants)
            {
                if (res.Rating >= 4.5)
                {
                    Console.WriteLine($"ร้าน: {res.Name} | คะแนน: {res.Rating}");
                }
            }
        }
    }

}
