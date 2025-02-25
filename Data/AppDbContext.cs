using Microsoft.EntityFrameworkCore;
using TacticWebApp.Models;

namespace TacticWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Score> Scores { get; set; } // Ensure Scores table is included
    }
}
