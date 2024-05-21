using BookStore.App.Data.Enums;
using BookStore.App.Models;
using BookStore.App.Services;
using BookStore.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    public class BookController : Controller
    {
        private IBookServices _bookServices;
        private readonly object _bookService;

        public BookController(IBookServices booksServices) => _bookServices = booksServices;
        public IActionResult Index()
        {
            var allBooks = _bookServices.GetAllBooks();

            var allBooksData = allBooks.Select(n => new GetBookVM()
            {
                Id = n.Id,
                Title = n.Title,
                Author = n.Author,
                URLimg = n.URLimg,

            }).ToList();

            return View(allBooksData);
        }

        public IActionResult Details(int id)
        {
            var book = _bookServices.GetBookById(id);


            return View(book);
        }
        //Create
        public IActionResult Create()
        {
            var newBook = new Book();
            return View(newBook);
        }

        [HttpPost]
        public IActionResult CreateConfirm([Bind("Title,Author,PublishedYear,NrOfPages,URLimg")]Book createBook)
        {
            if (!ModelState.IsValid)
            {
                return View(createBook);
            }
            _bookServices.Create(createBook);
            return RedirectToAction(nameof(Index));
        }

       

        //Get: Books/Modify/1
        public IActionResult Modify(int id)
        {
            var bookDetails = _bookServices.GetBookById(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost]
        public IActionResult ModifyConfirm(int id , [Bind("Title,Author,PublishedYear,NrOfPages,URLimg")] Book newbook)
        {
            if (!ModelState.IsValid)
            {
                return View(newbook);
            }
            _bookServices.Modify(id, newbook);
            return RedirectToAction(nameof(Index));
        }
        ///delete mv
        public IActionResult Delete(int id )
        {
            var bookDetails =  _bookServices.GetBookById(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost, ActionName("Delete")]
        public  IActionResult DeleteConfirm(int id)
        {
            var bookDetails =  _bookServices.GetBookById(id);
            if (bookDetails == null) return View("NotFound");

            _bookServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
