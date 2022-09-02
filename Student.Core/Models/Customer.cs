using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
    public class Customer : BaseEntity
    {
        [DisplayName("First Name")]
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(30)]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Street")]
        [StringLength(30)]
        [Required]
        public string Street { get; set; }

        [DisplayName("City")]
        [StringLength(10)]
        [Required]
        public string City { get; set; }
    }
}
