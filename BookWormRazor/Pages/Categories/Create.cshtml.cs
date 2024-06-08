using BookWormRazor.Data;
using BookWormRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookWormRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            dbContext.Categories.Add(Category);
            dbContext.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
