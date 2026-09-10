using System;
using System.Collections.Generic;

namespace WarehouseTracker
{
    // Модель товара на складе
    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total => Quantity * Price;

        public override string ToString()
        {
            return $"{Name,-20} | кол-во: {Quantity,4} | цена: {Price,10:C} | сумма: {Total,12:C}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=========================================");
            Console.WriteLine("   WarehouseTracker — Складской учёт");
            Console.WriteLine("   Автор: Иванов Иван");
            Console.WriteLine("=========================================");
            Console.WriteLine();

            var warehouse = new List<Product>
            {
                new Product { Name = "Клавиатура",  Quantity = 15,  Price = 1200.50m },
                new Product { Name = "Мышь",        Quantity = 42,  Price = 650.00m },
                new Product { Name = "Монитор",     Quantity = 7,   Price = 18500.00m },
                new Product { Name = "Кабель USB",  Quantity = 100, Price = 150.00m },
                new Product { Name = "Наушники",    Quantity = 23,  Price = 3400.00m }
            };

            Console.WriteLine("Текущее содержимое склада:");
            Console.WriteLine(new string('-', 70));

            decimal totalCost = 0m;
            int totalItems = 0;

            foreach (var product in warehouse)
            {
                Console.WriteLine(product);
                totalCost += product.Total;
                totalItems += product.Quantity;
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"Всего позиций: {warehouse.Count}");
            Console.WriteLine($"Всего единиц товара: {totalItems}");
            Console.WriteLine($"Общая стоимость склада: {totalCost:C}");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}