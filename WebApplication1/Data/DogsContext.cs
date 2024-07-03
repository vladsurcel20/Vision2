using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class DogsContext : DbContext
    {
        public DbSet<Dog> Dogs {get; set;}

        public string ConnectionString { get; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Mydb.db");
            base.OnConfiguring(optionsBuilder);

        }


    }
}
