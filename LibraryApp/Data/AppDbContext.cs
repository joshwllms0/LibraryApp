
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }
        public DbSet<Member> Members { get; set; } = null!;
    }
}
