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

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products
                           .Include(p => p.Cate)
                           .Where(p => p.Cate.Name == category)
                           .ToList();
        }
    }
}
