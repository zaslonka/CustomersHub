using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CustomersHub.Core.Contracts;
using CustomersHub.Core.Models;
using CustomersHub.Core.ViewModels;

namespace CustomersHub.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> context;
        private readonly IRepository<CustomerStatus> customerStatuses;
        private readonly IRepository<Note> customerNotes;

        public CustomerController(IRepository<Customer> customerContext, IRepository<CustomerStatus> customerStatusContext, IRepository<Note> customerNotesContext)
        {
            context = customerContext;
            customerStatuses = customerStatusContext;
            customerNotes = customerNotesContext;
        }

        public ActionResult Index()
        {
            List<Customer> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            CustomerManagingViewModel viewModel = new CustomerManagingViewModel();

            viewModel.Customer = new Customer();
            viewModel.CustomerStatuses = customerStatuses.Collection();
            return View(viewModel);
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
                CustomerManagingViewModel viewModel = new CustomerManagingViewModel();
                viewModel.Customer = customer;
                viewModel.CustomerStatuses = customerStatuses.Collection();

                return View(viewModel);
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

                return RedirectToAction("Details", "Customer", new { id = customer.Id });
            }
        }

        public ActionResult Details(string id)
        {
            var customer = context.Find(id);

            if (customer == null)
                return HttpNotFound();

            CustomerManagingViewModel viewModel = new CustomerManagingViewModel();
            viewModel.Customer = customer;
            viewModel.CustomerStatuses = customerStatuses.Collection();
            viewModel.CustomerNotes = customerNotes.Collection().Where(note => note.CustomerId == id);

            return View(viewModel);
        }
    }
}