using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult NewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            foreach (int num in newRentalDto.BookIds)
            {
                var book =_context.Books.Single(b => b.Id == num);
                if(book.AvailableAmount == 0) 
                {
                    return BadRequest("Book Id:" + book.Id + "is not available");
                }
                var rental = new Rental() { Customer = customer, Book = book, DateRented = DateTime.Now, IsActive = true };
                book.AvailableAmount--;
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult ReturnRental(NewRentalDto newRentalDto)
        {
            foreach (int bookId in newRentalDto.BookIds)
            {
                var rental = _context.Rentals.First(r => r.Book.Id == bookId && r.Customer.Id == newRentalDto.CustomerId &&
                r.IsActive == true);
                var book = _context.Books.Single(b => b.Id == bookId);
                rental.DateReturned = DateTime.Now;
                rental.IsActive = false;
                book.AvailableAmount++;
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
