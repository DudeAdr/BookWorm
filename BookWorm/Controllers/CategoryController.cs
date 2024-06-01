using BookWorm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext dbContext;
        public CategoryController(ApplicationDbContext DbContext) 
        {
            dbContext = DbContext;
        }

        public IActionResult Index()
        {
            var CategoryList = dbContext.Categories.ToList();
            return View(CategoryList);
        }
    }
}
