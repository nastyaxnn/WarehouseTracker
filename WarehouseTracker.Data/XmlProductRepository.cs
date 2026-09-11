using System.Xml.Serialization;
using WarehouseTracker.Logic;

namespace WarehouseTracker.Data;

public class XmlProductRepository : IProductRepository
{
    private readonly string _path;
    private readonly XmlSerializer _serializer = new(typeof(List<Product>));

    public XmlProductRepository(string path)
    {
        _path = path;
    }

    public List<Product> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Product>();
        }

        using var reader = new StreamReader(_path);
        return _serializer.Deserialize(reader) as List<Product> ?? new List<Product>();
    }

    public void Add(Product item)
    {
        List<Product> items = GetAll();
        items.Add(item);

        using var writer = new StreamWriter(_path);
        _serializer.Serialize(writer, items);
    }
}
