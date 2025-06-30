using Microsoft.EntityFrameworkCore;

public class BooksContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Using SQLite for simplicity; change as needed
        optionsBuilder.UseSqlite("Data Source=books.db");
    }
}