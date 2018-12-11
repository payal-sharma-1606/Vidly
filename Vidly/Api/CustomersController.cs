using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }

        /// <summary>
        /// GET : api/Customers
        /// </summary>
        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            return _Context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        /// <summary>
        /// GET : api/Customers/1
        /// </summary>
        public CustomerDto GetCustomer(int id)
        {
            var _CustomerDetails = _Context.Customers.SingleOrDefault(c => c.ID == id);
            if (_CustomerDetails == null)
                throw new HttpResponseException(HttpStatusCode.NotImplemented);

            return Mapper.Map<Customer, CustomerDto>(_CustomerDetails);
        }


        /// <summary>
        /// POST : api/Customers/1
        /// </summary>
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var _customer = Mapper.Map<CustomerDto, Customer>(customerDTO);

            _Context.Customers.Add(_customer);
            _Context.SaveChanges();

            customerDTO.ID = _customer.ID;


            return customerDTO;
        }


        /// <summary>
        /// PUT : api/Customers/1
        /// </summary>
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var _customer = _Context.Customers.SingleOrDefault(c => c.ID == id);
            if (_customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto,_customer);
            _Context.SaveChanges();
        }


        /// <summary>
        /// DELETE  : api/Customers/1
        /// </summary>
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var _customer = _Context.Customers.SingleOrDefault(c => c.ID == id);
            if (_customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _Context.Customers.Remove(_customer);

            _Context.SaveChanges();
        }
    }
}