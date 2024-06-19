using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        private ApplicationDbContext dbContext;
        public UnitOfWork(ApplicationDbContext DbContext)
        {
            dbContext = DbContext;
            Category = new CategoryRepository(dbContext);
            Product = new ProductRepository(dbContext);
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
