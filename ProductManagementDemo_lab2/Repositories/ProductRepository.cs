using System.Collections.Generic;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
        {
            return ProductDAO.Instance.GetProducts();
        }

        public Product? GetProductById(int id)
        {
            return ProductDAO.Instance.GetProductById(id);
        }

        public List<Product> SearchProductsByName(string name)
        {
            return ProductDAO.Instance.SearchProductsByName(name);
        }

        public Product CreateProduct(Product product)
        {
            return ProductDAO.Instance.CreateProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return ProductDAO.Instance.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return ProductDAO.Instance.DeleteProduct(id);
        }
    }
}
