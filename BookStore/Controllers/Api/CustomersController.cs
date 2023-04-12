﻿using AutoMapper;
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
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController() 
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
              .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customerDtos);
        }
        public IHttpActionResult GetCustomer(int id) 
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto) 
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDb == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerDb);
            
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id) 
        {
            var cutomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cutomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(cutomer);
            _context.SaveChanges();
        }
    }
}
