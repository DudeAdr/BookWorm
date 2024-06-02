using BookWorm.Data;
using BookWorm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category categoryObj)
        {
            if(categoryObj.Name == categoryObj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("name", "The Display Order can't exactly match the Name");
            }
            if(categoryObj.DisplayOrder.ToString() == "0")
            {
                ModelState.AddModelError("displayorder", "The Display Order can't be empty");
            }

            if(ModelState.IsValid)
            {
                dbContext.Categories.Add(categoryObj);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
