using System.Collections.Generic;
using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        List<Product> SearchProductsByName(string name);
        Product CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
