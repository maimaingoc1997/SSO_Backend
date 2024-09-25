using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _cateService; 
        public CategoriesController(ICategoryService cateService)
        {
            _cateService = cateService;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var categories = _cateService.GetCategories();
            return Ok(categories);
        }
    }
}
