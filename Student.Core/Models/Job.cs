using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Job: BaseEntity
    {

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Job Position")]
        [StringLength(30)]
        [Required]
        public string JobPosition { get; set; }

        [DisplayName("Salary Offered")]
        [Required]
        public decimal SalaryOffered { get; set; }

        [DisplayName("Business Name")]
        [StringLength(30)]
        [Required]
        public string BusinessName { get; set; }

        public string Image { get; set; }

        [DisplayName("Years Of Experience")]
        [StringLength(30)]
        [Required]
        public string Experience { get; set; }

        [DisplayName("University Name")]
        [StringLength(30)]
        [Required]
        public string University { get; set; }
        public bool Vaccinated { get; set; }

        [DisplayName("Shift Times")]
        [StringLength(20)]
        [Required]
        public string ShiftTimes { get; set; }

    }

}
