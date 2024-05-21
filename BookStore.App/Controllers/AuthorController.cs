using AuthorStore.App.Services;
using BookStore.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorStore.App.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorServices _authorServices;

        public AuthorController(IAuthorServices authorsServices) => _authorServices = authorsServices;
        public IActionResult Index()
        {
            var allAuthors = _authorServices.GetAllAuthors();

            return View(allAuthors);
        }

        public IActionResult Details(int id)
        {
            var author = _authorServices.GetAuthorById(id);


            return View(author);
        }
        //Create
        public IActionResult Create()
        {
            var newAuthor = new Author();
            return View(newAuthor);
        }

        [HttpPost]
        public IActionResult CreateConfirm([Bind("Name")] Author createAuthor)
        {
            if (!ModelState.IsValid)
            {
                return View(createAuthor);
            }
            _authorServices.Create(createAuthor);
            return RedirectToAction(nameof(Index));
        }



        //Get: Authors/Modify/1
        public IActionResult Modify(int id)
        {
            var authorDetails = _authorServices.GetAuthorById(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost]
        public IActionResult ModifyConfirm(int id , [Bind("Name")] Author newauthor)
        {
            if (!ModelState.IsValid)
            {
                return View(newauthor);
            }
            _authorServices.Modify(id, newauthor);
            return RedirectToAction(nameof(Index));
        }
        ///delete mv
        public IActionResult Delete(int id )
        {
            var authorDetails = _authorServices.GetAuthorById(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public  IActionResult DeleteConfirm(int id)
        {
            var authorDetails= _authorServices.GetAuthorById(id);
            if (authorDetails == null) return View("NotFound");

            _authorServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
