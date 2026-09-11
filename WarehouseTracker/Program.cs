using WarehouseTracker.Data;
using WarehouseTracker.Logic;

string jsonPath = Path.Combine(AppContext.BaseDirectory, "products.json");
string xmlPath  = Path.Combine(AppContext.BaseDirectory, "products.xml");

string kind = args.Length > 0 ? args[0] : "json";

IProductRepository repository = kind switch
{
    "xml"    => new XmlProductRepository(xmlPath),
    "memory" => new ProductRepository(),
    _        => new JsonProductRepository(jsonPath)
};

Console.WriteLine($"Хранилище: {kind}");
Console.WriteLine();

var service = new ProductService(repository);

Console.WriteLine("Название нового товара:");
string name = Console.ReadLine() ?? "";

Console.WriteLine("Количество:");
int.TryParse(Console.ReadLine(), out int quantity);

service.AddProduct(name, quantity);

Console.WriteLine();
Console.WriteLine("Все товары:");
foreach (var item in service.GetAllForDisplay())
{
    Console.WriteLine($"{item.Id}: {item.Name} — {item.Quantity} шт.");
}

Console.WriteLine();
Console.WriteLine($"Суммарное количество всех товаров: {service.GetTotalQuantity()} шт.");

Console.WriteLine();
Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey();
