# Books Inventory Management System

A .NET 8.0 console application for managing a books inventory using Entity Framework Core with Code-First approach.

## Features

- **Add Books**: Add new books with ISBN, name, author, and description
- **View All Books**: Display all books in the inventory
- **Search Books**: Search books by name, author, or ISBN
- **Update Books**: Modify existing book information
- **Delete Books**: Remove books from the inventory
- **Data Validation**: Input validation for all fields
- **Database Management**: Automatic database creation and management

## Database Schema

The application uses a `Book` entity with the following fields:

- **ISBN** (Primary Key): 13-character string, required
- **Name**: Book title, max 200 characters, required
- **AuthorName**: Author's name, max 100 characters, required
- **Description**: Book description, max 1000 characters, optional
- **CreatedDate**: Timestamp when the book was added
- **LastModifiedDate**: Timestamp when the book was last updated

## Technology Stack

- **.NET 8.0**: Latest .NET framework
- **Entity Framework Core 8.0**: ORM for database operations
- **SQL Server LocalDB**: Local database for development
- **Code-First Approach**: Database schema generated from C# models

## Prerequisites

- .NET 8.0 SDK
- SQL Server LocalDB (usually comes with Visual Studio or SQL Server Express)

## How to Run

1. Navigate to the project directory:
   ```bash
   cd 11.1
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

## Usage

The application provides a menu-driven interface:

1. **Add a new book**: Enter ISBN (13 digits), book name, author name, and optional description
2. **View all books**: See all books in a tabular format
3. **Search books**: Search by book name, author, or ISBN
4. **Update a book**: Modify existing book information
5. **Delete a book**: Remove a book with confirmation
6. **Exit**: Close the application

## Database Connection

The application uses SQL Server LocalDB with the connection string:
```
Server=(localdb)\mssqllocaldb;Database=BookInventory;Trusted_Connection=true;MultipleActiveResultSets=true
```

The database will be automatically created when you first run the application.

## Project Structure

```
11.1/
├── Models/
│   └── Book.cs                 # Book entity model
├── Data/
│   └── BookInventoryContext.cs # Entity Framework DbContext
├── Services/
│   └── BookInventoryService.cs # Business logic service
├── Program.cs                  # Main application entry point
├── 11.1.csproj                # Project file
└── README.md                  # This file
```

## Code-First Approach Benefits

- **Database Schema**: Automatically generated from C# models
- **Migrations**: Easy database schema updates
- **Type Safety**: Compile-time checking of database operations
- **Maintainability**: Database schema defined in code
- **Version Control**: Database schema changes tracked in source control

## Error Handling

The application includes comprehensive error handling for:
- Database connection issues
- Invalid input validation
- Duplicate ISBN prevention
- Missing book operations
- General exception handling

## Future Enhancements

Potential improvements could include:
- Book categories/genres
- Publication date tracking
- Price information
- Stock quantity management
- Export/import functionality
- User authentication
- Web API interface 