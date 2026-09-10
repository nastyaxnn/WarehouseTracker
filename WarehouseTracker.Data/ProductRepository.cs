using WarehouseTracker.Logic;
namespace WarehouseTracker.Data;

public class ProductRepository: IProductRepository
{
    private readonly List<Product> _items = new()
    {
        new Product { Id = 1, Name = "Клавиатура",  Quantity = 15 },
        new Product { Id = 2, Name = "Мышь",        Quantity = 4  }, // < 10
        new Product { Id = 3, Name = "Монитор",     Quantity = 7  }, // < 10
        new Product { Id = 4, Name = "Кабель USB",  Quantity = 100 },
        new Product { Id = 5, Name = "Наушники",    Quantity = 3  }  // < 10
    };

    public List<Product> GetAll()
    {
        return _items;
    }
}
