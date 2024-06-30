using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using BookWorm.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace BookWorm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IUnitOfWork UnitOfWork, IWebHostEnvironment WebHostEnvironment)
        {
            unitOfWork = UnitOfWork;
            webHostEnvironment = WebHostEnvironment;

        }
        public IActionResult Index()
        {
            var productList = unitOfWork.Product.GetAll().ToList();

            return View(productList);
        }

        public IActionResult Upsert(int? id) //Update and insert
        {
            ProductVM productVM = new()
            {
                CategoryList = unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if(id == null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }          
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productObj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                if(file != null) 
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if(!string.IsNullOrEmpty(productObj.Product.ImageUrl)) 
                    {
                        var oldImagePath = Path.Combine(wwwRootPath,productObj.Product.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath)) 
                        { 
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productObj.Product.ImageUrl = @"\images\product\" + fileName;
                }
                
                if(productObj.Product.Id == 0)
                {
                    unitOfWork.Product.Add(productObj.Product);
                }
                else
                {
                    unitOfWork.Product.Update(productObj.Product);
                }
                
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
