using Microsoft.EntityFrameworkCore;
using CustomApi.Models;
using System;

namespace CustomApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          modelBuilder.Entity<Product>()
          .Property(p => p.Price)
          .HasPrecision(18, 2); // Precision of 18 and scale of 2

        // Seed data for Authors
          modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", DateOfBirth = new DateTime(1980, 1, 1) },
            new Author { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com", DateOfBirth = new DateTime(1985, 5, 10) },
            new Author { Id = 3, FirstName = "Mark", LastName = "Taylor", Email = "marktaylor@example.com", DateOfBirth = new DateTime(1990, 3, 25) },
            new Author { Id = 4, FirstName = "Emily", LastName = "Brown", Email = "emilybrown@example.com", DateOfBirth = new DateTime(1992, 8, 14) },
            new Author { Id = 5, FirstName = "Daniel", LastName = "Williams", Email = "danielwilliams@example.com", DateOfBirth = new DateTime(1978, 12, 5) }
          );

        // Seed data for Products
          modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.99M, StockQuantity = 100, ReleaseDate = new DateTime(2023, 1, 1) },
            new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 25.50M, StockQuantity = 50, ReleaseDate = new DateTime(2023, 2, 1) },
            new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 15.75M, StockQuantity = 75, ReleaseDate = new DateTime(2023, 3, 1) },
            new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 35.00M, StockQuantity = 25, ReleaseDate = new DateTime(2023, 4, 1) },
            new Product { Id = 5, Name = "Product 5", Description = "Description 5", Price = 50.99M, StockQuantity = 10, ReleaseDate = new DateTime(2023, 5, 1) }
          );
        }
    }
}
