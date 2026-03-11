using EntityFramework_Connection.Models;
using EntityFramework_Connection.Models.EntityFramework_Connection.Models;
using Join_LINQ_EF_CORE.Model.EntityFramework_Connection.Models;
using Microsoft.EntityFrameworkCore;

namespace Join_LINQ_EF_CORE.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=Entity_Framework_Practice;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
