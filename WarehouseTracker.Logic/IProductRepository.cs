namespace WarehouseTracker.Logic;

public interface IProductRepository
{
    List<Product> GetAll();
    void Add(Product item);
}
