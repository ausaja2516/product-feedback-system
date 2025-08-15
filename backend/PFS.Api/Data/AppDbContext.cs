using Microsoft.EntityFrameworkCore;
using PFS.Api.Models;

namespace PFS.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "UI" },
            new Category { Id = 2, Name = "UX" },
            new Category { Id = 3, Name = "Enhancement" },
            new Category { Id = 4, Name = "Bug" },
            new Category { Id = 5, Name = "Feature" }
            );
        }
        

    }
}