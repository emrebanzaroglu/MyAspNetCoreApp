using Microsoft.EntityFrameworkCore;

namespace MyAspNetCoreApp.Web.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Product> Product { get; set; } //burada belirttiğim isim ile databasedeki isim aynı olmalı
        public DbSet<Visitors> Visitors { get; set; } //burada belirttiğim isim ile databasedeki isim aynı olmalı
    }
}
