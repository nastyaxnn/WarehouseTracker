using WarehouseTracker.Data;

namespace WarehouseTracker.Logic;

public class ProductService
{
    private readonly ProductRepository _repository = new();

    // Правило отбора варианта 2: товары с количеством меньше 10
    public List<Product> GetLowStock()
    {
        return _repository.GetAll()
            .Where(p => p.Quantity < 10)
            .ToList();
    }
}
