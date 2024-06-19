using BookWorm.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fantasy", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Novel", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Action", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    Description = "A novel written by American author F. Scott Fitzgerald.",
                    ISBN = "9780743273565",
                    Author = "F. Scott Fitzgerald",
                    ListPrice = 10.99,
                    Price = 8.99,
                    Price50 = 7.99,
                    Price100 = 6.99,
                    Category = "Novel"
                },
                new Product
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    Description = "A novel by Harper Lee published in 1960.",
                    ISBN = "9780061120084",
                    Author = "Harper Lee",
                    ListPrice = 14.99,
                    Price = 12.99,
                    Price50 = 10.99,
                    Price100 = 9.99,
                    Category = "Novel"
                },
                new Product
                {
                    Id = 3,
                    Title = "1984",
                    Description = "A dystopian social science fiction novel and cautionary tale by the English writer George Orwell.",
                    ISBN = "9780451524935",
                    Author = "George Orwell",
                    ListPrice = 15.99,
                    Price = 13.99,
                    Price50 = 11.99,
                    Price100 = 10.99,
                    Category = "SciFi"
                },
                new Product
                {
                    Id = 4,
                    Title = "Pride and Prejudice",
                    Description = "A romantic novel of manners written by Jane Austen.",
                    ISBN = "9781503290563",
                    Author = "Jane Austen",
                    ListPrice = 9.99,
                    Price = 7.99,
                    Price50 = 6.99,
                    Price100 = 5.99,
                    Category = "Romantic Novel"
                });
        }
    }
}
