using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersHub.Core.Models;

namespace CustomersHub.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("CustomersHubConnection") { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerStatus> CustomerStatuses { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}
