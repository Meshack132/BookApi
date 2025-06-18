// Controllers/BooksController.cs
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static readonly List<Book> _books = new()
    {
        new Book(1, "C# in Depth"),
        new Book(2, "ASP.NET Core Essentials")
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(_books);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Book book)
    {
        _books.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }
}

public record Book(int Id, string Title);