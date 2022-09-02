using Student.Core.Contracts;
using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class OrderManagerController : Controller
    {
        IOrderService orderService;
        IRepository<Driver> driverContext;

        public OrderManagerController(IOrderService OrderService, IRepository<Driver> DriverContext)
        {
            this.orderService = OrderService;
            this.driverContext = DriverContext;
        }
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();
            orders = orderService.GetOrderList().Where(p => p.OrderStatus != "Order Complete").OrderByDescending(p => p.CreatedAt).ToList();
            return View(orders);
        }
        public ActionResult OrderHistory()
        {
            List<Order> orders = orderService.GetOrderList();
            orders = orderService.GetOrderList().Where(p => p.OrderStatus == "Order Complete").OrderByDescending(p => p.CreatedAt).ToList();
            return View(orders);
        }

        public ActionResult PrepareOrdersForDelivery() //All Orders which require delivery but need drivers to be assigned
        {
            List<Order> orders = orderService.GetOrderList();
            orders = orderService.GetOrderList().Where(p => (p.Driver == "Not Assigned" && p.DeliveryMethod == "Deliver To My Door" && p.OrderStatus == "Payment Processed")).OrderBy(p => p.CreatedAt).ToList();

            return View(orders);
        }

        public ActionResult PrepareDelivery(string Id)//Prepare individual order for delivery by assigning driver
        {
            Order order = orderService.GetOrder(Id);
            order.Drivers = driverContext.Collection();
            return View(order);
        }
        [HttpPost]
        public ActionResult PrepareDelivery(Order preparedOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);
            //Get all drivers
            order.Drivers = driverContext.Collection();
            string orderUniversity = order.University.ToString(); //Get Order Suburb

            var findDriverAllocatedToUni = order.Drivers.Where(d => d.University.ToString() == orderUniversity).FirstOrDefault(); //Get Driver Allocated to Uni

            if (findDriverAllocatedToUni != null)
            {
                order.Driver = findDriverAllocatedToUni.DriverName; //Assign Driver Automatically             
            }

            //Send Email to Customer to notify of order progression

            string customer = order.Email; //Returns the customers email
            string fname = order.FirstName; //Returns the customers first name


            string receiver = customer;
            string subject = "Student Hub Order Delivery Details ";
            string message = "Hi " + fname + " We are currently processing your order.The order will be delivered within 7-10 working days. See you soon!";

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("campuswork2021@outlook.com", "Student Hub");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "Campuswork";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp-mail.outlook.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            //Send Email to Driver to notify them about delivery


            string driver = "studenthubdriver@outlook.com"; //Returns the drivers email
            string fname2 = order.FirstName; //Returns the customers first name


            string receiver2 = driver;
            string subject2 = "Order Delivery Details";
            string message2 = "Hi " + order.Driver + "The following order needs to be delivered within 7-10 working days.The delivery details are below:" +
                "Delivery Address: " + order.Street +
                "Customer Name: " + order.FirstName + " " + order.LastName +
                "Order ID: " + order.Id;

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("campuswork2021@outlook.com",subject2);
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "Campuswork";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp-mail.outlook.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    //return View();
                }

            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }



            order.OrderStatus = "Order Ready";
            orderService.UpdateOrder(order);

            return RedirectToAction("PrepareOrdersForDelivery");
        }

        public ActionResult PrepareOrdersForCollection() //All Orders which require to be picked up
        {
            List<Order> orders = orderService.GetOrderList();
            orders = orderService.GetOrderList().Where(p => (p.Driver == "Not Assigned" && p.DeliveryMethod == "I'll Pick It Up" && p.OrderStatus == "Payment Processed")).OrderBy(p => p.CreatedAt).ToList();

            return View(orders);
        }

        public ActionResult PrepareCollection(string Id)
        {
            Order order = orderService.GetOrder(Id);
            return View(order);
        }
        [HttpPost]
        public ActionResult PrepareCollection(Order preparedOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);
           

            //Send Email to Customer to notify of order progression

            string customer = order.Email; //Returns the customers email
            string fname = order.FirstName; //Returns the customers first name


            string receiver = customer;
            string subject = "Student Hub Order Collection Details ";
            string message = "Hi " + fname + " We are currently processing your order.The order can be collected within 7-10 working days. See you soon!";

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("campuswork2021@outlook.com", "Student Hub");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "Campuswork";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp-mail.outlook.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            order.OrderStatus = "Order Ready";
            orderService.UpdateOrder(order);

            return RedirectToAction("PrepareOrdersForCollection");
        }

        public ActionResult OrderCollections()
        {
            List<Order> orders = orderService.GetOrderList();
            orders = orderService.GetOrderList().Where(p => (p.Driver == "Not Assigned" && p.DeliveryMethod == "I'll Pick It Up" && p.OrderStatus == "Order Ready")).OrderBy(p => p.CreatedAt).ToList();

            return View(orders);
        }

        public ActionResult DriverDeliveries()
        {
            List<Order> orders = orderService.GetOrderList();
            orders = orderService.GetOrderList().Where(p => (p.Driver != "Not Assigned" && p.DeliveryMethod == "Deliver To My Door" && p.OrderStatus == "Order Ready")).OrderBy(p => p.CreatedAt).ToList();

            return View(orders);
        }
        
        public ActionResult OrderComplete(Order updatedOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = "Order Complete";

            orderService.UpdateOrder(order);

     
            return RedirectToAction("Index");
        }
    }

}