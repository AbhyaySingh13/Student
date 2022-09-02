using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") //Looks in Web.Config/App.Config and looks for Default Connection string
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<FaultLog> FaultLogs { get; set; }

    }

}