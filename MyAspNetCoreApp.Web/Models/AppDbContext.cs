using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Product> Product { get; set; } //burada belirttiğim isim ile databasedeki isim aynı olmalı
        public DbSet<Visitors> Visitors { get; set; } 
        public DbSet<MyAspNetCoreApp.Web.Models.Category> Category { get; set; }
    }
}
