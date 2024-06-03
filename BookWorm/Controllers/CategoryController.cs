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
            if (categoryObj.Name == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order can't exactly match the Name");
            }
            if (categoryObj.DisplayOrder.ToString() == "0")
            {
                ModelState.AddModelError("displayorder", "The Display Order can't be empty");
            }

            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(categoryObj);
                dbContext.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }
            Category? categoryFromDb = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(categoryObj);
                dbContext.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = dbContext.Categories.FirstOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteRecord(int? id)
        {
            Category? obj = dbContext.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            dbContext.Categories.Remove(obj);
            dbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
