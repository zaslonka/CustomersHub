using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersHub.Core.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        [StringLength(30, ErrorMessage = "Customer name cannot be longer than 30 characters.")]
        [DisplayName("Customer Name")]
        public string Name { get; set; }

        //[Required]
        public string Status { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number. Phone should look like this 000-000-0000 ")]
        public string Phone { get; set; }

        [DisplayName("E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
