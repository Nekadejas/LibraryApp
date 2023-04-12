using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            if(User.IsInRole("CanManageBooks"))
                return View("List");

            return View("ReadOnlyList");
        }
        public ActionResult BookForm()
        {
            var viewModel = new BookFromViewModel() { Genres = _context.Genres.ToList() };
            return View(viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult CreateEdit(Book book)
        {
            if (!ModelState.IsValid) 
            {
                var viewModel = new BookFromViewModel(book);
                viewModel.Genres = _context.Genres.ToList();
                return View("BookForm", viewModel);
            }
            if (book.Id == 0)
            {
               book.AddedToDb = DateTime.Now;
               book.AvailableAmount = book.Amount;
                _context.Books.Add(book);
            }
            else
            {
                var bookDb = _context.Books.Single(b => b.Id == book.Id);
                bookDb.Name = book.Name;
                bookDb.GenreId = book.GenreId;
                bookDb.Amount = book.Amount;
                bookDb.ReleaseDate = book.ReleaseDate;
                bookDb.Author = book.Author;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFromViewModel(book)
            {
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", viewModel);

        }

    }
}