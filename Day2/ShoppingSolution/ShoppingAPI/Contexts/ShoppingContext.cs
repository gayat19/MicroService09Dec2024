using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Models;

namespace ShoppingAPI.Contexts
{
    public class ShoppingContext :DbContext
    {
        public ShoppingContext(DbContextOptions options) : base(options)//initializes the connection string in the base class
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding the tabel with data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 101, Title = "Laptop", PricePerUnit = 45000, Description = "Lenovo Laptop", StockAvailable = 10 },
                new Product { Id = 102, Title = "Mobile", PricePerUnit = 15000, Description = "Samsung Mobile", StockAvailable = 20 },
                new Product { Id = 103, Title = "Tablet", PricePerUnit = 25000, Description = "Apple Tablet", StockAvailable = 5 },
                new Product { Id = 104, Title = "Smart Watch", PricePerUnit = 5000, Description = "MI Smart Watch", StockAvailable = 15 } ,
                new Product { Id = 105, Title = "Headphones", PricePerUnit = 2000, Description = "Boat Headphones", StockAvailable = 25 } 
            );
        }
    }
}
