# BookApi - RESTful Book Management API 📚


BookApi is a fully functional RESTful API built with ASP.NET Core 9.0 that allows you to manage a collection of books. It features in-memory storage, CRUD operations, and comes with a PowerShell script to populate sample data.

## Features ✨

- **Full CRUD Operations** - Create, Read, Update, Delete books
- **Minimal API Design** - Clean and efficient implementation
- **In-Memory Storage** - No database setup required
- **Interactive Documentation** - Built-in Swagger UI
- **Sample Data Script** - PowerShell script to populate books
- **Text Database Export** - Save book information to TXT file
- **Error Handling** - Comprehensive error responses
- **RESTful Design** - Standard HTTP methods and status codes

## Getting Started 🚀

### Prerequisites

- [.NET SDK 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- PowerShell 5.1+ (Windows) or PowerShell Core (Cross-platform)
- IDE (Visual Studio 2022 or VS Code with C# extension)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Meshack132/BookApi.git
   cd BookApi
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Access the API at:
   - `http://localhost:5000` (HTTP)
   - `https://localhost:7000` (HTTPS)
   - Interactive docs: `http://localhost:5000/swagger`

## API Endpoints 📡

| Method | Endpoint       | Description                     | Status Codes               |
|--------|----------------|---------------------------------|----------------------------|
| GET    | `/books`       | Get all books                   | 200 OK                     |
| GET    | `/books/{id}`  | Get a book by ID                | 200 OK, 404 Not Found      |
| POST   | `/books`       | Add a new book                  | 201 Created, 400 Bad Request |
| PUT    | `/books/{id}`  | Update an existing book         | 200 OK, 404 Not Found      |
| DELETE | `/books/{id}`  | Delete a book                   | 204 No Content, 404 Not Found |

### Book Model
```json
{
  "id": 1,
  "title": "Clean Code",
  "author": "Robert C. Martin"
}
```

### Example Requests

**Create a new book:**
```bash
curl -X POST http://localhost:5000/books \
  -H "Content-Type: application/json" \
  -d '{"id": 1, "title": "Clean Code", "author": "Robert C. Martin"}'
```

**Get all books:**
```bash
curl http://localhost:5000/books
```

**Update a book:**
```bash
curl -X PUT http://localhost:5000/books/1 \
  -H "Content-Type: application/json" \
  -d '{"title": "Clean Code: A Handbook of Agile Software Craftsmanship"}'
```

## Using the Sample Data Script 📖

The PowerShell script `add-books.ps1` adds sample books to the API and saves them to a text file:

1. Run the API: `dotnet run`
2. Execute the script:
   ```powershell
   Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
   .\add-books.ps1
   ```
   
3. Sample output:
   ```
   📚 Starting book import to BookApi...
      API Endpoint: http://localhost:5000/books
      Saving books to: books-database.txt

   ✅ Added book: 'Clean Code'
      Author: Robert C. Martin
   ✅ Added book: 'The Pragmatic Programmer'
      Author: Andrew Hunt, David Thomas
   ...

   📊 Import Summary
      Total books in API: 5
      Books processed: 5
      Books saved to: books-database.txt
   ```

4. View the text database:
   ```powershell
   cat .\books-database.txt
   ```

## Project Structure 🗂️

```
BookApi/
├── Properties/
│   └── launchSettings.json    # Runtime configuration
├── add-books.ps1              # Sample data script
├── books-database.txt         # Generated book database
├── Program.cs                 # Main application entry point
├── BookApi.csproj             # Project configuration
└── appsettings.json           # Configuration settings
```

## Troubleshooting ⚠️

**Common Issues:**

1. **Port conflicts**:
   ```bash
   # Find processes using port 5000
   netstat -ano | findstr :5000
   
   # Kill process by PID
   taskkill /F /PID <PID>
   ```

2. **File lock during build**:
   ```bash
   taskkill /F /IM BookApi.exe /T
   dotnet clean
   dotnet run
   ```

3. **PowerShell execution policy**:
   ```powershell
   # Temporary solution
   Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
   
   # Permanent solution (requires admin)
   Set-ExecutionPolicy RemoteSigned
   ```

4. **API not responding**:
   ```powershell
   # Test connection
   Test-NetConnection localhost -Port 5000
   ```

## Contributing 🤝

Contributions are welcome! Follow these steps:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a pull request

## License 📄

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
**Happy coding!** 💻 If you have any questions, please open an issue in the GitHub repository.
