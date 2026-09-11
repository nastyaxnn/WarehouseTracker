using WarehouseTracker.Logic;

namespace WarehouseTracker.Data;

public class DemoProductRepository : IProductRepository
{
    public List<Product> GetAll()
    {
        return new List<Product>
        {
            new Product { Id = 100, Name = "Демонстрационный товар", Quantity = 1 }
        };
    }

    public void Add(Product item)
    {
        // Демонстрационное хранилище доступно только для чтения
    }
}
