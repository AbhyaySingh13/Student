using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.ViewModels
{
    public class DeviceViewModel
    {
        public Device Device { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}
