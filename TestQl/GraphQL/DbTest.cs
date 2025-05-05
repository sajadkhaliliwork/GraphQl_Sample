// GraphQL/Query.cs
using TestQl.Models;

namespace TestQl.GraphQL;

public static class DbTest
{
    static List<Book> books = new List<Book>      {
            new Book { Id = 1, Title = "نبرد من", Author = "آدولف هیتلر" },
            new Book { Id = 2, Title = "1984", Author = "جورج اورول" },
            new Book { Id = 3, Title = "بینوایان", Author = "ویکتور هوگو" }
        };

    public static List<Book> GetBooks()
    {
        return books;
    }
    public static Book AddBook(string title ,string author )
    {


        var book = new Book()
        {
            Author = author,
            Title = title,
            Id = books.Max(book => book.Id)
        };
        books.Add(book);
        return book;
    }
}