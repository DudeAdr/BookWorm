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
            var objFromDb = dbContext.Products.FirstOrDefault(product => product.Id == product.Id);
            if(objFromDb != null)
            {
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.ISBN = product.ISBN;
                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.Price100 = product.Price100;
                objFromDb.Author = product.Author;
                objFromDb.CategoryId = product.CategoryId;

                if(objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
