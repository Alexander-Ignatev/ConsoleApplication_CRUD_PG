using HomeWork_4.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace HomeWork_4
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
