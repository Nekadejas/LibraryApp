using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookStore.ViewModels;
using System.Data.Entity.Infrastructure.MappingViews;

namespace BookStore.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Custmoers
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);    
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerForm()
        {
            var viewModel = new CustomerFormViewModel() 
            { 
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = new Customer()
            };
            return View(viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateEdit(CustomerFormViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                viewModel.MembershipTypes = _context.MembershipTypes.ToList();
                return View("CustomerForm",viewModel);
            }
            if(viewModel.Customer.Id == 0) 
            {
                _context.Customers.Add(viewModel.Customer);
            }
            else 
            {
                var customerDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);
                customerDb.Name = viewModel.Customer.Name;
                customerDb.BirthDate = viewModel.Customer.BirthDate;
                customerDb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                customerDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }
    }
}