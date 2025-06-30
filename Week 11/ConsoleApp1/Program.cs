// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using var context = new BooksContext();
context.Database.EnsureCreated();

// Add a sample book
if (!context.Books.Any())
{
    context.Books.Add(new Book
    {
        ISBN = "978-1234567890",
        Name = "Sample Book",
        AuthorName = "Jane Doe",
        Description = "A sample book for demonstration."
    });
    context.SaveChanges();
}

// List all books
foreach (var book in context.Books)
{
    Console.WriteLine($"{book.ISBN}: {book.Name} by {book.AuthorName} - {book.Description}");
}
