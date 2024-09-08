
# Library Management System API

## Overview

This project is a **Library Management System API** built using **.NET Core 8**. The API supports basic CRUD (Create, Read, Update, Delete) operations for managing books and authors. It follows best practices such as the use of **DTOs (Data Transfer Objects)** to decouple data models from API contracts, **AutoMapper** for efficient mapping between entities and DTOs, and the **Repository Pattern** to abstract data access logic.

## Features

- **CRUD Operations**: Manage books and authors within the library system.
- **Entity Framework Core**: Handle data persistence with ease.
- **AutoMapper Integration**: Simplify object-object mapping between entities and DTOs.
- **Repository Pattern**: Encapsulate the data access logic and promote clean code.
- **Swagger/OpenAPI**: Integrated API documentation for easy testing and exploration.

## Project Structure

```
LibraryManagementSystem/
│
├── Controllers/
│   ├── BooksController.cs
│   └── AuthorsController.cs
│
├── Data/
│   └── LibraryContext.cs
│
├── DTOs/
│   ├── BookDto.cs
│   └── AuthorDto.cs
│
├── Interfaces/
│   ├── IBookRepository.cs
│   └── IAuthorRepository.cs
│
├── Mappings/
│   └── LibraryProfile.cs
│
├── Models/
│   ├── Book.cs
│   └── Author.cs
│
├── Repositories/
│   ├── BookRepository.cs
│   └── AuthorRepository.cs
│
├── Program.cs
└── appsettings.json
```

## Getting Started

### Prerequisites

- [.NET Core 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other database supported by Entity Framework Core.

### Setup

1. **Clone the repository**:
   ```bash
   git clone https://github.com/apantzar/LibraryAPI.git
   cd LibraryAPI
   ```

2. **Configure the database connection**:
   - Update the `appsettings.json` file with your database connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "YourDatabaseConnectionString"
     }
   }
   ```

3. **Apply Migrations and Update the Database**:
   ```bash
   dotnet ef database update
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

5. **Access the API documentation**:
   - The API documentation is available at `https://localhost:{PORT}/swagger` when the application is running in development mode.

## Usage

### API Endpoints

- **Books**
  - `GET /api/Books`: Retrieve all books.
  - `GET /api/Books/{id}`: Retrieve a book by ID.
  - `POST /api/Books`: Create a new book.
  - `PUT /api/Books/{id}`: Update an existing book.
  - `DELETE /api/Books/{id}`: Delete a book by ID.

- **Authors**
  - `GET /api/Authors`: Retrieve all authors.
  - `GET /api/Authors/{id}`: Retrieve an author by ID.
  - `POST /api/Authors`: Create a new author.
  - `PUT /api/Authors/{id}`: Update an existing author.
  - `DELETE /api/Authors/{id}`: Delete an author by ID.

---

Happy Coding! 😊
