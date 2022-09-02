using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
      public class FaultLog : BaseEntity
    {

        [StringLength(20)]
        [DisplayName("First Name:")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(20)]
        [DisplayName("Last Name:")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(500)]
        [DisplayName("Residential Address:")]
        public string ResidentialAddress { get; set; }

        [StringLength(10)]
        [DisplayName("Cell Number:")]
        public string CellNumber { get; set; }

        public string Technician { get; set; }
        public IEnumerable<Technician> Technicians { get; set; }

        [DisplayName("Fault Type:")]
        public string FaultType { get; set; }

        public string Description { get; set; }

        public string Urgency { get; set; }

        public string Status { get; set; }
    }
}
