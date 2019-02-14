using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersHub.Core.Models
{
    public class Note : BaseEntity
    {
        [Required]
        [StringLength(30, ErrorMessage = "Note title cannot be longer than 30 characters.")]
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public string Description { get; set; }
    }
}
