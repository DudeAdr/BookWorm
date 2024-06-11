using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;

namespace BookWorm.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
        private ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
            dbContext = DbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            dbContext.Update(category);
        }
    }
}
