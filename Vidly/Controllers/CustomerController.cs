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
            var customers = _Context.Customers.Include(c=>c.MembershipType);

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
            return View();
        }
    }
}