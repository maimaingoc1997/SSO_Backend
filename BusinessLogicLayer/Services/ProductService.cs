using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public IEnumerable<Product> GetProductByCategory(int categoryId)
        {
            if (_categoryRepository.isRootCategory(categoryId))
            {
                return _productRepository.GetProductsByParentCategory(categoryId);
            }
            return _productRepository.GetProductsByCategory(categoryId);
        }
        public IEnumerable<Product> GetActiveProductsByCategory(int categoryId)
        {
            if (_categoryRepository.isRootCategory(categoryId))
            {
                return _productRepository.GetActiveProductsByParentCategory(categoryId);
            }
            return _productRepository.GetActiveProductsByCategory(categoryId);
        }
        public IEnumerable<Product> GetDeActiveProductsByCategory(int categoryId)
        {
            if (_categoryRepository.isRootCategory(categoryId))
            {
                return _productRepository.GetDeActiveProductsByParentCategory(categoryId);
            }
            return _productRepository.GetDeActiveProductsByCategory(categoryId);
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            return _productRepository.SearchByName(name);
        }

        public IEnumerable<Product> GetProductsByStatus(int status)
        {
           return _productRepository.GetProductsByStatus(status);
        }

        public Product? GetProductById(int productId)
        {
            return _productRepository.GetProductByID(productId);
        }
    }
}
