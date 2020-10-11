using HCI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HCI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes  { get; set; }

        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}