using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository
    {
        private readonly HmwebsiteContext _context;

        public ProductRepository(HmwebsiteContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                           .Where(p => p.CateId == categoryId)
                           .ToList();
        }

        public IEnumerable<Product> GetProductsByParentCategory(int categoryId)
        {
            return _context.Products
                           .Where(p => p.Cate.ParentId == categoryId)
                           .ToList();
        }
        public IEnumerable<Product> SearchByName(string name)
        {
            return _context.Products.Where(p =>
            p.Name.Contains(name)).ToList();
        }

        public IEnumerable<Product> GetProductsByStatus(int status)
        {
            return _context.Products.Where(p => p.Status == status).ToList();
        }

        public IEnumerable<Product> GetActiveProductsByCategory(int categoryId)
        {
            return GetProductsByCategory(categoryId).Where(p => p.Status == 1).ToList();
        }
        public IEnumerable<Product> GetDeActiveProductsByCategory(int categoryId)
        {
            return GetProductsByCategory(categoryId).Where(p => p.Status == 0).ToList();
        }
        public IEnumerable<Product> GetActiveProductsByParentCategory(int categoryId)
        {
            return GetProductsByParentCategory(categoryId).Where(p => p.Status == 1).ToList();
        }
        public IEnumerable<Product> GetDeActiveProductsByParentCategory(int categoryId)
        {
            return GetProductsByParentCategory(categoryId).Where(p => p.Status == 0).ToList();
        }
        public Product? GetProductByID(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
