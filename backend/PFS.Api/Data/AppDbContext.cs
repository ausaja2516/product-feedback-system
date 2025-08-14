using Microsoft.EntityFrameworkCore;
using PFS.Api.Models;

namespace PFS.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

    }
}