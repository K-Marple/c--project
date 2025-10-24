using System.Collections.Generic;
using System.Linq;
using catalog.models;

namespace catalog.services
{
    public class Library
    {
        private List<Book> books = new List<Book>();
        public List<Book> AllBooks() => books;
        public Book FindByISBN(string isbn) => books.Find(b => b.ISBN == isbn);
        public Book FindByTitle(string title) => books.Find(b => b.Title == title);
        public void AddBook(Book book) => books.Add(book);

    }
}