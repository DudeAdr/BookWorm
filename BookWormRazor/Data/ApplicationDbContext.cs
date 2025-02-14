﻿using BookWormRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWormRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 3 },
                new Category { Id = 2, Name = "Thriller", DisplayOrder = 4 },
                new Category { Id = 3, Name = "Novel", DisplayOrder = 5 }
                );
        }
    }
}
