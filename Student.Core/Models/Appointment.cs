using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Appointment : BaseEntity
    {
        public string ListingId { get; set; }

        [DisplayName("Student Name")]
        [StringLength(50)]
        [Required]
        public string StudentName { get; set; }

        [Required]
        [DisplayName("Appointment Date/Time")]
        [DataType(DataType.Date)]
        public string AppointmentDate { get; set; }


    }
}
