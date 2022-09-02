using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
    class DebitOrder: BaseEntity
    {
        [Required]
        [DisplayName("Account Number")]
        public string AccNum { get; set; }

        [Required]
        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [Required]
        [DisplayName("Brach Code")]
        public string BranchCode { get; set; }

        [Required]
        [DisplayName("Debit Order date")]
        public string DebDate { get; set; }

        [Required]
        [DisplayName("Type Of Account")]
        public string AccType { get; set; }
    }

}
