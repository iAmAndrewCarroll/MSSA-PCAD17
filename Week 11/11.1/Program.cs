using _11._1.Data;
using _11._1.Models;
using _11._1.Services;

namespace _11._1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Books Inventory Management System ===");
            Console.WriteLine("Using Code-First Approach with Entity Framework Core");
            Console.WriteLine();

            // Initialize database and services
            var context = new BookInventoryContext();
            var bookService = new BookInventoryService(context);
            
            try
            {
                await bookService.InitializeDatabaseAsync();
                Console.WriteLine("Database initialized successfully!");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
                return;
            }

            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddBook(bookService);
                        break;
                    case "2":
                        await ViewAllBooks(bookService);
                        break;
                    case "3":
                        await SearchBooks(bookService);
                        break;
                    case "4":
                        await UpdateBook(bookService);
                        break;
                    case "5":
                        await DeleteBook(bookService);
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Thank you for using Books Inventory Management System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. View all books");
            Console.WriteLine("3. Search books");
            Console.WriteLine("4. Update a book");
            Console.WriteLine("5. Delete a book");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");
        }

        static async Task AddBook(BookInventoryService bookService)
        {
            Console.WriteLine("\n=== Add New Book ===");
            
            Console.Write("Enter ISBN (13 digits): ");
            string? isbn = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13)
            {
                Console.WriteLine("Invalid ISBN. Must be exactly 13 characters.");
                return;
            }

            Console.Write("Enter book name: ");
            string? name = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Book name cannot be empty.");
                return;
            }

            Console.Write("Enter author name: ");
            string? authorName = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(authorName))
            {
                Console.WriteLine("Author name cannot be empty.");
                return;
            }

            Console.Write("Enter book description (optional): ");
            string? description = Console.ReadLine();

            var book = new Book
            {
                ISBN = isbn,
                Name = name,
                AuthorName = authorName,
                Description = description
            };

            bool success = await bookService.AddBookAsync(book);
            if (success)
            {
                Console.WriteLine("Book added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add book. ISBN might already exist.");
            }
        }

        static async Task ViewAllBooks(BookInventoryService bookService)
        {
            Console.WriteLine("\n=== All Books ===");
            
            var books = await bookService.GetAllBooksAsync();
            
            if (!books.Any())
            {
                Console.WriteLine("No books found in inventory.");
                return;
            }

            Console.WriteLine($"{"ISBN",-15} {"Name",-30} {"Author",-20} {"Created Date",-12}");
            Console.WriteLine(new string('-', 80));
            
            foreach (var book in books)
            {
                Console.WriteLine($"{book.ISBN,-15} {book.Name,-30} {book.AuthorName,-20} {book.CreatedDate:yyyy-MM-dd}");
            }
            
            Console.WriteLine($"\nTotal books: {books.Count}");
        }

        static async Task SearchBooks(BookInventoryService bookService)
        {
            Console.WriteLine("\n=== Search Books ===");
            Console.Write("Enter search term (book name, author, or ISBN): ");
            string? searchTerm = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term cannot be empty.");
                return;
            }

            var books = await bookService.SearchBooksAsync(searchTerm);
            
            if (!books.Any())
            {
                Console.WriteLine("No books found matching your search criteria.");
                return;
            }

            Console.WriteLine($"\nSearch results for '{searchTerm}':");
            Console.WriteLine($"{"ISBN",-15} {"Name",-30} {"Author",-20}");
            Console.WriteLine(new string('-', 70));
            
            foreach (var book in books)
            {
                Console.WriteLine($"{book.ISBN,-15} {book.Name,-30} {book.AuthorName,-20}");
            }
        }

        static async Task UpdateBook(BookInventoryService bookService)
        {
            Console.WriteLine("\n=== Update Book ===");
            Console.Write("Enter ISBN of the book to update: ");
            string? isbn = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("ISBN cannot be empty.");
                return;
            }

            var existingBook = await bookService.GetBookByISBNAsync(isbn);
            if (existingBook == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"Current book: {existingBook.Name} by {existingBook.AuthorName}");
            Console.WriteLine();

            Console.Write("Enter new book name (or press Enter to keep current): ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                name = existingBook.Name;

            Console.Write("Enter new author name (or press Enter to keep current): ");
            string? authorName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(authorName))
                authorName = existingBook.AuthorName;

            Console.Write("Enter new description (or press Enter to keep current): ");
            string? description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
                description = existingBook.Description;

            var updatedBook = new Book
            {
                ISBN = isbn,
                Name = name,
                AuthorName = authorName,
                Description = description
            };

            bool success = await bookService.UpdateBookAsync(updatedBook);
            if (success)
            {
                Console.WriteLine("Book updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update book.");
            }
        }

        static async Task DeleteBook(BookInventoryService bookService)
        {
            Console.WriteLine("\n=== Delete Book ===");
            Console.Write("Enter ISBN of the book to delete: ");
            string? isbn = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("ISBN cannot be empty.");
                return;
            }

            var book = await bookService.GetBookByISBNAsync(isbn);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"Are you sure you want to delete '{book.Name}' by {book.AuthorName}? (y/n)");
            string? confirm = Console.ReadLine()?.ToLower();
            
            if (confirm == "y" || confirm == "yes")
            {
                bool success = await bookService.DeleteBookAsync(isbn);
                if (success)
                {
                    Console.WriteLine("Book deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to delete book.");
                }
            }
            else
            {
                Console.WriteLine("Delete operation cancelled.");
            }
        }
    }
}
