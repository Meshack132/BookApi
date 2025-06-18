using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using BookApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Swagger + Endpoint API explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global error handler (generic for production)
app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext context) =>
    Results.Problem(title: "An unexpected error occurred."));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// In-memory store
var books = new List<Book>
{
    new Book { Id = 1, Title = "C# in Depth" },
    new Book { Id = 2, Title = "ASP.NET Core Essentials" }
};

// Routes
app.MapGet("/books", () => books);

app.MapGet("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(b => b.Id == id);
    return book is null ? Results.NotFound() : Results.Ok(book);
});

app.MapPost("/books", (Book book) =>
{
    // Manual model validation
    var context = new ValidationContext(book);
    var results = new List<ValidationResult>();

    if (!Validator.TryValidateObject(book, context, results, true))
        return Results.BadRequest(results);

    books.Add(book);

    // Logging after successful add
    app.Logger.LogInformation("Book added: {Id}, Title: {Title}", book.Id, book.Title);

    return Results.Created($"/books/{book.Id}", book);
});

app.Run();
