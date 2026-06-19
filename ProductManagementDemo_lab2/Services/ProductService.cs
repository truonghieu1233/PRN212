using System;
using System.Collections.Generic;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> SearchProductsByName(string name)
        {
            return _productRepository.SearchProductsByName(name);
        }

        public Product CreateProduct(Product product)
        {
            ValidateProduct(product);
            return _productRepository.CreateProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            ValidateProduct(product);
            return _productRepository.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        private void ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new ArgumentException("Product name is required.");

            if (product.Price.HasValue && product.Price < 0)
                throw new ArgumentException("Price cannot be negative.");

            if (product.UnitsInStock.HasValue && product.UnitsInStock < 0)
                throw new ArgumentException("Units in stock cannot be negative.");
        }
    }
}
