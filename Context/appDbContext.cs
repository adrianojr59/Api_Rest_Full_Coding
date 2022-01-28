using Api_Rest_Full_Coding.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Rest_Full_Coding.Context
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> option) : base(option) { }

        public DbSet<Product> ProductList { get; set; }
        public DbSet<Category> CategoryList { get; set; }


    }
}
