using catalog.models;
using catalog.services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Library>();

var app = builder.Build();

app.MapGet("/", () => "Welcome to the Library");

app.MapGet("/books", (Library library) =>
{
    return library.AllBooks();
});

app.MapGet("/books/{title}", (string title, Library library) =>
{
    var book = library.FindByTitle(title);
    return Results.Ok(book);
});

app.MapGet("/books/{isbn}", (string isbn, Library library) =>
{
    var book = library.FindByISBN(isbn);
    return Results.Ok(book);
});

app.MapGet("/books/add", (Book book, Library library) =>
{
    library.AddBook(book);
    return Results.Created($"/books/{book.Title}", book);
});

app.Run();