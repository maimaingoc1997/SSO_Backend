using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository
    {
        private readonly HmwebsiteContext _context;

        public CategoryRepository(HmwebsiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }

        public bool isRootCategory(int categoryId)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.Id == categoryId); 

            if( category != null && category.ParentId == 0) return true;

            return false;
        }


    }
}
