using System.Collections.Generic;

public static class DataSource
{
    private static IList<Book> _books { get; set; }

    public static IList<Book> GetBooks()
    {
        if (_books != null)
        {
            return _books;
        }

        _books = new List<Book>();

        System.Guid x1 = System.Guid.NewGuid();
        System.Guid x2 = System.Guid.NewGuid();

        // book #1
        Book book = new Book
        {
            Id = 1,
            ISBN = "978-0-321-87758-1",
            Title = "Essential C#5.0",
            Author = "Mark Michaelis",
            Price = 59.99m,
            Location = new Address { City = "Redmond", Street = "156TH AVE NE" },
            PressId = x1,
            Press = new Press
            {
                PressId = x1,
                Name = "Addison-Wesley",
                Category = Category.Book
            }
        };
        _books.Add(book);

        // book #2
        book = new Book
        {
            Id = 2,
            ISBN = "063-6-920-02371-5",
            Title = "Enterprise Games",
            Author = "Michael Hugos",
            Price = 49.99m,
            Location = new Address { City = "Bellevue", Street = "Main ST" },
            PressId = x2,
            Press = new Press
            {
                PressId = x2,
                Name = "O'Reilly",
                Category = Category.EBook,
            }
        };
        _books.Add(book);

        return _books;
    }
}