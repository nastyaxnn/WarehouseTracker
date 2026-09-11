namespace WarehouseTracker.Logic;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    // Правило отбора из практической 1.2: количество < 10
    public List<Product> GetLowStock()
    {
        return _repository.GetAll()
            .Where(p => p.Quantity < 10)
            .ToList();
    }

    // Показ всех товаров (для вывода в консоли)
    public List<Product> GetAllForDisplay()
    {
        return _repository.GetAll();
    }

    // Новый метод: добавление товара
    public void AddProduct(string name, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            return;

        int nextId = _repository.GetAll().Count + 1;

        _repository.Add(new Product
        {
            Id = nextId,
            Name = name,
            Quantity = quantity
        });
    }

    // Самостоятельная часть: суммарное количество всех товаров
    public int GetTotalQuantity()
    {
        return _repository.GetAll().Sum(p => p.Quantity);
    }
}
