using CustomersHub.Core.Contracts;
using CustomersHub.Core.Models;
using CustomersHub.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CustomersHub.WebUI.Tests.Controllers
{
    class CustomerControllerTest
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void IndexPageReturnCustomers()
            {
                IRepository<Customer> customerContext = new Mocks.MockContext<Customer>();
                IRepository<CustomerStatus> customerStatusContext = new Mocks.MockContext<CustomerStatus>();
                IRepository<Note> noteContext = new Mocks.MockContext<Note>();

                customerContext.Insert(new Customer());

                CustomerController controller = new CustomerController(customerContext, customerStatusContext, noteContext);

                var result = controller.Index("","") as ViewResult;

                Assert.IsNotNull(result);
            }
        }
    }
}
