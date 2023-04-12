using AutoMapper;
using BookStore.Dtos;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;
        public BooksController() 
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetBooks(string query = null) 
        {
            var booksQuery = _context.Books
              .Include(c => c.Genre).Where(b => b.AvailableAmount > 0);

            if (!String.IsNullOrWhiteSpace(query))
                booksQuery = booksQuery.Where(b => b.Name.Contains(query));

            var booksDtos = booksQuery
                .ToList()
                .Select(Mapper.Map<Book, BookDto>);

            return Ok(booksDtos);
        }
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book == null)
                return NotFound();

            return Ok(Mapper.Map<Book,BookDto>(book));

        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto) 
        {
            if(!ModelState.IsValid)
                return BadRequest();

            bookDto.AddedToDb = DateTime.Now;
            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
            bookDto.Id = book.Id;
            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);

        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return BadRequest();

            bookDto.AddedToDb = book.AddedToDb;
            Mapper.Map(bookDto, book);
            _context.SaveChanges();
            return Ok(bookDto);

        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public IHttpActionResult DeleteBook(int id) 
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
