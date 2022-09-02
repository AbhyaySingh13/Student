using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
    class Feedback:BaseEntity
    {

        [DisplayName("Student Name")]
        [StringLength(30)]
        [Required]
        public string StudentName { get; set; }
        [DisplayName("PropertyId")]
        public string PropertyId { get; set; }
        [Required]
        [DisplayName("Date/Time")]
        public DateTime DateTime { get; set; }
        [StringLength(30)]

        [Required]
        public string Address { get; set; }
        [Required]
        public string FeedBack { get; set; }
    }
}



