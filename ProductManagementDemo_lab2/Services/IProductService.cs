using System.Collections.Generic;
using BusinessObjects;

namespace Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        List<Product> SearchProductsByName(string name);
        Product CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
