using ContactAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAppApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("contacts");
            modelBuilder.Entity<User>().ToTable("users");

            base.OnModelCreating(modelBuilder);
        }
    }
}
