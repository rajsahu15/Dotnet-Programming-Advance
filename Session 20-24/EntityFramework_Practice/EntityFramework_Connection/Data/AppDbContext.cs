using Microsoft.EntityFrameworkCore;
using EntityFramework_Connection.Models;

namespace EntityFramework_Connection.Data
{
    public class AppDbContext : DbContext
    {
       public DbSet<Employee> Employees { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=Entity_Framework_Practice;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
