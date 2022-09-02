using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Driver : BaseEntity
    {
        [DisplayName("Driver Name")]
        [Required]
        public string DriverName { get; set; }

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }
        public UniversityName University { get; set; }
        public bool Availability { get; set; }

        public enum UniversityName
        {
            Damelin,
            DUT,
            UKZN,
            Mangosuthu,
            Regent,
            Mancosa,
            Inscape,
            Zululand
        }


    }
}
