using Microsoft.EntityFrameworkCore;
using bookStoreApp.Models.Entities;

namespace bookStoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
