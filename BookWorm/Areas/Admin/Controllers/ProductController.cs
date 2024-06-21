﻿using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using BookWorm.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWorm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductController(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            var productList = unitOfWork.Product.GetAll().ToList();

            return View(productList);
        }

        public IActionResult Create()
        {
            ProductVM productVM = new()
            {
                CategoryList = unitOfWork.Category.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM productObj)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Add(productObj.Product);
                unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productObj.CategoryList = unitOfWork.Category.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            };

            return View(productObj);
        }
    

        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = unitOfWork.Product.Get(c => c.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product productObj)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Update(productObj);
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
            Product? productFromDb = unitOfWork.Product.Get(c => c.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteRecord(int? id)
        {
            Product? productFromDb = unitOfWork.Product.Get(c => c.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            unitOfWork.Product.Remove(productFromDb);
            unitOfWork.Save();
            TempData["success"] = "Category removed successfully";
            return RedirectToAction("Index");
        }
    }
}
