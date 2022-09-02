using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.ViewModels
{
   public class ListingViewModel
    {
        public Listing Listing { get; set; }
        public IEnumerable<Listing> Listings { get; set; }
    }
}
