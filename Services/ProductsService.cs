using ProductApi.Models;

namespace ProductApi.Services;

public static class ProductService
{
    static List<Product> Products { get; }
    static ProductService()
    {
        Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "This is product 1",
                Price = 49.99M
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "This is product 2",
                Price = 20M
            },
        };
    }

    public static List<Product> GetAll() => Products;

    public static Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);

    public static void Add(Product product)
    {
        Products.Add(product);
    }

    public static void Delete(int id)
    {
        var product = Get(id);
        if (product is null)
            return;

        Products.Remove(product);
    }

    public static void Update(Product product)
    {
        var index = Products.FindIndex(p => p.Id == product.Id);
        if (index == -1)
            return;

        Products[index] = product;
    }
}