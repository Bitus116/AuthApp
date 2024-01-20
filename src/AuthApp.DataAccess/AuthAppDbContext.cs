using AuthApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.DataAccess
{
    public class AuthAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AuthAppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}