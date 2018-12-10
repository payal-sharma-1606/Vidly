using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Vidly.DataContracts;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private ApplicationDbContext _Context;

        public CustomerController()
        {
            _Context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        public ViewResult Index()
        {
            // by default dbcontext load only customer object and not the related objects
            //Include() methods do this thing: this is called eager loading
            var customers = _Context.Customers.Include(c => c.MembershipType);

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customerDetail = _Context.Customers.Include(c => c.MembershipType).SingleOrDefault(a => a.ID == id);
            //var customerDetail = GetCustomers().FirstOrDefault(a => a.ID == id.GetValueOrDefault()) as Customer;

            if (customerDetail == null)
                HttpNotFound();
            return View(customerDetail);
        }

        public ActionResult New()
        {
            var membershipTypes = _Context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //if (ModelState.ContainsKey("customer.ID"))
            //    ModelState["customer.ID"].Errors.Clear();
            ///instead i can initialize customer class in the CustomerFormViewModel with new Customer()


            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _Context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.ID == 0)
                _Context.Customers.Add(customer);
            else
            {
                var customerInDb = _Context.Customers.Single(c => c.ID == customer.ID);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _Context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var _customerData = _Context.Customers.FirstOrDefault(c => c.ID == id);
            if (_customerData == null)
                return HttpNotFound();

            var _viewModel = new CustomerFormViewModel
            {
                Customer = _customerData,
                MembershipTypes = _Context.MembershipTypes.ToList()
            };

            return View("CustomerForm", _viewModel);
        }
    }
}