using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Drink> Drinks { get; set; }
    }
}
