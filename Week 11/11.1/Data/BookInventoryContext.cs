using Microsoft.EntityFrameworkCore;
using _11._1.Models;

namespace _11._1.Data
{
    public class BookInventoryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BookInventory;Trusted_Connection=true;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.ISBN);
                entity.Property(e => e.ISBN).HasMaxLength(13);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.AuthorName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(1000);
            });
        }
    }
} 