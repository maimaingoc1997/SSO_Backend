using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductByCategory(int category);

        IEnumerable<Product> SearchByName(string name);

        IEnumerable<Product> GetProductsByStatus(int status);

        IEnumerable<Product> GetDeActiveProductsByCategory(int categoryId);

        IEnumerable<Product> GetActiveProductsByCategory(int categoryId);

        Product? GetProductById(int productId);
    }
}
