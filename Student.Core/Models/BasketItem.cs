using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string BasketId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
    }
}
