using BookStore.App.Models;

namespace BookStore.App.Data.Enums
{
    public static class FakeData
    {
        public static List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", PublishedYear = 1949, NrOfPages = 328 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublishedYear = 1960, NrOfPages = 281 },
            new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublishedYear = 1925, NrOfPages = 218 },
            new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", PublishedYear = 1813, NrOfPages = 432 },
            new Book { Id = 5, Title = "Catch-22", Author = "Joseph Heller", PublishedYear = 1961, NrOfPages = 453 }
        };

            return books;
        }
    }
}
