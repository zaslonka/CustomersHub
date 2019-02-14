using System.Collections.Generic;
using CustomersHub.Core.Models;

namespace CustomersHub.Core.ViewModels
{
    public class CustomerManagingViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<CustomerStatus> CustomerStatuses { get; set; }
    }
}
