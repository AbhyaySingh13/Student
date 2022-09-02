using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Order : BaseEntity
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }


        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        [DisplayName("Order Status")]
        public string OrderStatus { get; set; }

        [DisplayName("Delivery Method")]
        public string DeliveryMethod { get; set; }

        [DisplayName("Basket Total")]
        public decimal BasketTotal { get; set; }

        [DisplayName("Final Total")]
        public decimal FinalTotal { get; set; }
        public UniversityList University { get; set; }

        public enum UniversityList
        {
            Damelin,
            DUT,
            UKZN,
            Mangosuthu,
            Regent,
            Mancosa,
            Inscape,
            Zululand
        }
        public string Driver { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
