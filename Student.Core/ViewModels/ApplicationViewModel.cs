using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.ViewModels
{
   public class ApplicationViewModel
    {
        public Application Application { get; set; }
        public IEnumerable<Application> Applications { get; set; }
    }
}
