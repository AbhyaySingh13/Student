using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.ViewModels
{
    public class JobViewModel
    {
        public Job Job { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
    }
}
