using System.Text.Json;
using System.Text.Encodings.Web;
using WarehouseTracker.Logic;

namespace WarehouseTracker.Data;

public class JsonProductRepository : IProductRepository
{
    private readonly string _path;

    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public JsonProductRepository(string path)
    {
        _path = path;
    }

    public List<Product> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Product>();
        }

        string text = File.ReadAllText(_path);
       
try{ return JsonSerializer.Deserialize<List<Product>>(text) ?? new List<Product>();
    }
catch (JsonException)
{
	return new List<Product>();
}}

    public void Add(Product item)
    {
        List<Product> items = GetAll();
        items.Add(item);

        string text = JsonSerializer.Serialize(items, _options);
        File.WriteAllText(_path, text);
    }
}

