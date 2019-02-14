using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomersHub.Core.Contracts;
using CustomersHub.Core.Models;
using CustomersHub.DataAccess.LocalMemory;

namespace CustomersHub.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> context;
        private readonly IRepository<CustomerStatus> customerStatuses;

        public CustomerController(IRepository<Customer> customerContext, IRepository<CustomerStatus> customerStatusContext)
        {
            context = customerContext;
            customerStatuses = customerStatusContext;
        }

        public ActionResult Index()
        {
            List<Customer> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            Customer product = new Customer();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            else
            {
                context.Insert(customer);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Customer customer = context.Find(Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        [HttpPost]
        public ActionResult Edit(Customer customer, string Id)
        {
            Customer customerToEdit = context.Find(Id);

            if (customerToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(customer);
                }

                customerToEdit.City = customer.City;
                customerToEdit.Status = customer.Status;
                customerToEdit.Country = customer.Country;
                customerToEdit.Email = customer.Email;
                customerToEdit.Name = customer.Name;
                customerToEdit.Phone = customer.Phone;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}