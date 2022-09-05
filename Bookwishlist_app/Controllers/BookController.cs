using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookwishlist_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookwishlist_app.Controllers
{
    public class BookController : Controller
    {
        // GET: /<controller>/
       

        private readonly IBookRepository repo;

        public BookController(IBookRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var books = repo.GetAllBooks();
            return View(books);
        }

        public IActionResult ViewBook(int id)
        {
            var book = repo.GetBook(id);
            return View(book);
        }


        public IActionResult UpdateBook(int id)
        {
            Book book = repo.GetBook(id);
            if (book == null)
            {
                return View("BookNotFound");
            }
            return View(book);
        }

        public IActionResult UpdateBookToDatabase(Book book)
        {
            repo.UpdateBook(book);

            return RedirectToAction("ViewBook", new { id = book.ID });
        }


        public IActionResult InsertBook()
        {
            
            return View();
        }

        public IActionResult InsertBookToDatabase(Book bookToInsert)
        {
            repo.InsertBook(bookToInsert);
            return RedirectToAction("Index");
        }

    }
}

