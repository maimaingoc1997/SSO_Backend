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

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts(); 
        }
    }
}
