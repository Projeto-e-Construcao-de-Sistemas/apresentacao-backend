using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo;

public class AppDbContext : DbContext {

    public DbSet<Category> category { get; set; }
    public DbSet<Product> product { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=demopcs;User Id=SA;Password=Demo12!@;TrustServerCertificate=Yes;");
}
