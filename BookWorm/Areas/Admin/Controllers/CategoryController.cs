using BookWorm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;

namespace BookWorm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        public IActionResult Index()
        {
            var CategoryList = unitOfWork.Category.GetAll();
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

            if (ModelState.IsValid)
            {
                unitOfWork.Category.Add(categoryObj);
                unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = unitOfWork.Category.Get(c => c.Id == id);
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
                unitOfWork.Category.Update(categoryObj);
                unitOfWork.Save();
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
            Category? categoryFromDb = unitOfWork.Category.Get(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteRecord(int? id)
        {
            Category? obj = unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            unitOfWork.Category.Remove(obj);
            unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
