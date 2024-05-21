using BookStore.App.Data;
using BookStore.App.Models;

namespace AuthorStore.App.Services
{
    public class AuthorsServices : IAuthorServices
    {
        //deklarimi i appdbcontext
        private AppDbContext _context;
        public AuthorsServices(AppDbContext context)
        {
            _context = context;
        }


        public string GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAllAuthors()
        {
            var allAuthors = _context.Authors.ToList();
            return allAuthors;
        }
        

        public void Delete(int id)
        {
            var result = _context.Authors.FirstOrDefault(n => n.Id == id);
            _context.Authors.Remove(result);
            _context.SaveChanges();
        }

       
        public Author GetAuthorById(int id)
        {
            var newAuthor = _context.Authors
                .FirstOrDefault(n => n.Id == id);

            return newAuthor;
        }

        public Author Modify(int id, Author newAuthor)
        {
            var result = _context.Authors.FirstOrDefault(n => n.Id == id);
            result.Name = newAuthor.Name;
            //result.Author = newBook.Author;
            //result.NrOfPages = newBook.NrOfPages;
            //result.PublishedYear = newBook.PublishedYear;
            //result.URLimg = newBook.URLimg; 

            _context.Authors.Update(result);
            _context.SaveChanges();
            return newAuthor;
        }

        public Author Create(Author createAuthor)
        {
            _context.Authors.Add(createAuthor);
            _context.SaveChanges();
            return createAuthor;
        }
    }

}