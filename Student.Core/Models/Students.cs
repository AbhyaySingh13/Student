using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Students : BaseEntity
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
        [StringLength(30)]
        [Required]
        public string Email { get; set; }

        [DisplayName("Cell Number")]
        [StringLength(20)]
        [Required]
        public string CellNumber { get; set; }

        [DisplayName("University Name")]
        [StringLength(30)]
        [Required]
        public string University { get; set; }

        [DisplayName("Faculty")]
        [StringLength(50)]
        [Required]
        public string Faculty { get; set; }

        [DisplayName("Qualification")]
        [StringLength(50)]
        [Required]
        public string Qualification { get; set; }

        [Required]
        public bool Vaccinated { get; set; }

        [Required]
        public int NumYears { get; set; }

        [Required]
        public bool Bursary { get; set; }

        [DisplayName("Emergency Contact First Name")]
        [StringLength(30)]
        [Required]
        public string EmergencyFirstName { get; set; }

        [DisplayName("Relation")]
        [StringLength(30)]
        [Required]
        public string Relation { get; set; }

        [DisplayName("Emergency Contact Cell Number")]
        [StringLength(20)]
        [Required]
        public string EmergencyCellNum { get; set; }

    }
}
