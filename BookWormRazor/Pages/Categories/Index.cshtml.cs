using BookWormRazor.Data;
using BookWormRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookWormRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext dbContext;
        public List<Category> Categories { get; set; }
        public IndexModel(ApplicationDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public void OnGet()
        {
            Categories = dbContext.Categories.ToList();
        }
    }
}
