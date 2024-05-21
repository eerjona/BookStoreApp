using BookStore.App.Models;

namespace AuthorStore.App.Services
{
    public interface IAuthorServices
    {
        List<BookStore.App.Models.Author> GetAllAuthors();
        BookStore.App.Models.Author GetAuthorById(int id);
        BookStore.App.Models.Author Modify(int id, Author newAuthor);
        BookStore.App.Models.Author Create(Author createAuthor);
        void Delete(int id);
    }
}
