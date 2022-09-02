using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Listing: BaseEntity
    {

        [DisplayName("Area")]
        [StringLength(50)]
        [Required]
        public string Area { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }

       
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }

        
        [Required]
        public string Description { get; set; }

        [DisplayName("Bedrooms")]
        [Required]
        public int NumBedrooms { get; set; }

        [DisplayName("Bathrooms")]
        [Required]
        public int NumBathrooms { get; set; }

        [DisplayName("Garages")]
        [Required]
        public int NumGarages { get; set; }

        [DisplayName("University")]
        [StringLength(30)]
        [Required]
        public string University { get; set; }

        [Required]
        public bool  Alarm { get; set; }
 
        [Required]
        public bool Fencing { get; set; }


        [Required]
        public bool Wifi { get; set; }

        [DisplayName("Owner Name")]
        [StringLength(50)]
        [Required]
        public string OwnerName { get; set; }

        [DisplayName("Owner Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string OwnerEmail { get; set; }

        [DisplayName("Owner Contact Details")]
        [StringLength(50)]
        [Required]
        public string NumOwner { get; set; }

        //[DisplayName("Student Name")]
        //[StringLength(30)]
        //[Required]
        //public string StudentName { get; set; }

        //[Required]
        //[DisplayName("Appointment Date/Time")]
        //[DataType(DataType.Date)]
        //public DateTime AppointmentDateTime { get; set; }
    }
}
