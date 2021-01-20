using BB.CodeTest.Data;
using BB.CodeTest.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BB.CodeTest.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext Context { get; }
        public CustomerController(ApplicationDbContext _context)
        {
            this.Context = _context;
        }

        // GET: CustomerController

        public ActionResult Index()
        {
            var customers = Context.Customers.ToList();
            return View(customers);
        }

     

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Add
        public ActionResult Add()
        {
            //int Id = 3;
            string FirstName = "firstname";
            string LastName = "lastname";
            string Address = "address";
            string City = "city";
            string State = "state";
            string ZipCode = "zipcode";
            int OrganizationId = 4;
            //Organization = new Organization()
            //    {
            //        int Id = 5;
            //string name = "testorg";
            //OrgSize orgSize = OrgSize.Medium;
            //    }
            var Customer = new Customer()
            {
                //Id = Id,
                OrganizationId = OrganizationId,
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                City = City,
                State = State,
                ZipCode = ZipCode,
                Organization = new Organization()
            };
            this.Context.Customers.Add(Customer);
            this.Context.SaveChanges();
            return View(new Customer());
        }

 

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

     

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = this.Context.Customers.First(c => c.Id == id);

            this.Context.Remove(customer);

            this.Context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

      
    }
}
