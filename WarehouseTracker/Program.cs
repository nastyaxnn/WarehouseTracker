using WarehouseTracker.Data;
using WarehouseTracker.Logic;

IProductRepository repository = new ProductRepository();

var service = new ProductService(repository);

Console.WriteLine("=========================================");
Console.WriteLine("   WarehouseTracker — Складской учёт");
Console.WriteLine("   Автор: Сиволап А.В.");
Console.WriteLine("=========================================");
Console.WriteLine();
Console.WriteLine("Товары с количеством меньше 10:");
Console.WriteLine(new string('-', 50));

foreach (var item in service.GetLowStock())
{
    Console.WriteLine($"{item.Id}: {item.Name} — {item.Quantity} шт.");
}

Console.WriteLine();
Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey();

