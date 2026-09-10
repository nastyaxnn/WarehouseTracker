namespace WarehouseTracker.Logic;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    // Правило отбора варианта 2: товары с количеством меньше 10
    public List<Product> GetLowStock()
    {
        return _repository.GetAll()
            .Where(p => p.Quantity < 10)
            .ToList();
    }
}

