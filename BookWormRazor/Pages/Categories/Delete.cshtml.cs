using BookWormRazor.Data;
using BookWormRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookWormRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {     
        private readonly ApplicationDbContext dbContext;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext DbContext)
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
            Category? obj = dbContext.Categories.Find(Category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            dbContext.Categories.Remove(obj);
            dbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
