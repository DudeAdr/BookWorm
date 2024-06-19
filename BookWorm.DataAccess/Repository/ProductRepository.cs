using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext dbContext;
        public ProductRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
            dbContext = DbContext;
        }
        public void Update(Product product)
        {
            dbContext.Update(product);
        }
    }
}
