using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static ProductDAO? instance;
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null) instance = new ProductDAO();
                return instance;
            }
        }

        public List<Product> GetProducts()
        {
            using var context = new MyStoreContext();
            return context.Products.Include(p => p.Category).ToList();
        }

        public Product? GetProductById(int id)
        {
            using var context = new MyStoreContext();
            return context.Products.Include(p => p.Category)
                                    .FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> SearchProductsByName(string name)
        {
            using var context = new MyStoreContext();
            return context.Products.Include(p => p.Category)
                                    .Where(p => p.ProductName.Contains(name))
                                    .ToList();
        }

        public Product CreateProduct(Product product)
        {
            using var context = new MyStoreContext();
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public bool UpdateProduct(Product product)
        {
            using var context = new MyStoreContext();
            var existing = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existing == null) return false;

            existing.ProductName = product.ProductName;
            existing.Price = product.Price;
            existing.UnitsInStock = product.UnitsInStock;
            existing.CategoryId = product.CategoryId;

            context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int id)
        {
            using var context = new MyStoreContext();
            var existing = context.Products.FirstOrDefault(p => p.ProductId == id);
            if (existing == null) return false;

            context.Products.Remove(existing);
            context.SaveChanges();
            return true;
        }
    }
}
