using Microsoft.EntityFrameworkCore;
using InfraSkillsPro.Models;

namespace InfraSkillsPro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define a DbSet for each entity in your application
        public DbSet<Item> Items { get; set; }

        // Optional: Override OnModelCreating to configure relationships or schema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example configuration
            modelBuilder.Entity<Item>().HasKey(i => i.Id);
        }
    }
}
