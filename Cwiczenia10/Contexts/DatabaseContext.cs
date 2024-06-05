using Cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>().HasData(new List<Account>
        {
            new Account
            {
                PkAccount = 1,
                FkRole = 1,
                FirstName = "fname",
                LastName = "lname",
                Email = "email@email.pl",
                Phone = "000111222"
            }
        });

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new Role
            {
                PkRole = 1,
                Name = "name"
            }
        });

        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            new Product
            {
                PkProduct = 1,
                Name = "name",
                Weight = 10.00m,
                Width = 10.00m,
                Height = 10.00m,
                Depth = 10.00m
            }
        });

        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category
            {
                PkCategory = 1,
                Name = "category"
            }
        });
    }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
}