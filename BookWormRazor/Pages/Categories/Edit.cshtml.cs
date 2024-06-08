using BookWormRazor.Data;
using BookWormRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookWormRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category? Category { get; set; }
        public EditModel(ApplicationDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = dbContext.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(Category);
                dbContext.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
