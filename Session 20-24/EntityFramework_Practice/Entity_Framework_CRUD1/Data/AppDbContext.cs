using Microsoft.EntityFrameworkCore;
using EntityFramework_Connection.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_Connection.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
      "Server=localhost\\SQLEXPRESS;Database=Entity_Framework_Practice;Trusted_Connection=True;TrustServerCertificate=True;Connection" +
      " Timeout=30");
        }

        // ✅ Override methods INSIDE the class
        public override int SaveChanges()
        {
            ValidateSalaryRange();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ValidateSalaryRange();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        // ✅ Private validation method INSIDE the class
        private void ValidateSalaryRange()
        {
            var employees = ChangeTracker.Entries<Employee>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var emp in employees)
            {
                if (emp.Entity.Salary < 0)
                    throw new ArgumentException("Salary cannot be negative");
            }
        }
    }
}
