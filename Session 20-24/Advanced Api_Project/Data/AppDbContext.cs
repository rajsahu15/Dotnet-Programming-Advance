using Microsoft.EntityFrameworkCore;
using ImprovedApiProject.Entities;

namespace ImprovedApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}