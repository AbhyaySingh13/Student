using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Device: BaseEntity
    {
        [DisplayName("Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
     
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }

        [DisplayName("Memory")]
        [StringLength(30)]
        [Required]
        public string Memory { get; set; }

        [DisplayName("Operating System")]
        [StringLength(30)]
        [Required]
        public string OperatingSystem { get; set; }

        [DisplayName("Processor Type")]
        [StringLength(20)]
        [Required]
        public string ProcessorType { get; set; }

        [DisplayName("Hard Drive")]
        [StringLength(30)]
        [Required]
        public string HardDrive { get; set; }

        [DisplayName("Graphics Card")]
        [StringLength(30)]
        [Required]
        public string GraphicsCard { get; set; }

        [Required]
        [DisplayName("Virus Protection")]
        public bool VirusProtect { get; set; }

        [Required]
        [DisplayName("Years of Warranty")]
        public int YearsOfWarranty { get; set; }
        
    }
}
