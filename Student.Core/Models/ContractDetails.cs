using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
    class ContractDetails: BaseEntity
    {

        [DisplayName("Student Name")]
        [StringLength(30)]
        [Required]
        public string StudentName { get; set; }

        [DisplayName("PropertyId")]
        public string PropertyId { get; set; }

        [Required]
        [DisplayName("Number of Occupants")]
        public int NumOccupants { get; set; }

        [Required]
        [DisplayName("Duration Of Course")]
        public string DurationofCourse { get; set; }

        [Required]
        [DisplayName("Funding Type")]
        public string FundingType { get; set; }

        [Required]
        [DisplayName("Next Of Kin")]
        public string NextOfKin { get; set; }

        [Required]
        [DisplayName("Next Of Kin Contact")]
        public string KinContact { get; set; }

        [Required]
        public string FeedBack { get; set; }
    }
}
