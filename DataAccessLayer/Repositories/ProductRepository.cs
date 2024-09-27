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

    }
}
