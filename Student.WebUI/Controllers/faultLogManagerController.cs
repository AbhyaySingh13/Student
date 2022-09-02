using Student.Core.Contracts;
using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace LightYear.WebUI.Controllers
{
    [Authorize(Users = "21956096@dut4life.ac.za")]
    public class FaultLogManagerController : Controller
    {
        IRepository<Technician> technician;
        IRepository<Customer> customers;
        IOrderService orderService;

        public FaultLogManagerController(IRepository<Technician> technicianContext, IRepository<Customer> customers, IOrderService OrderService) //Needs to inject Repositories from DI Container
        {
            technician = technicianContext;
            this.customers = customers;
            this.orderService = OrderService;
        }

        public ActionResult Index()
        {
            List<FaultLog> faultLogs = orderService.GetFaultList();

            return View(faultLogs);
        }
        public ActionResult UpdateFaultLog(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Delivered",
                "Pending Delivery",
                "Technician Dispatched"
            };
            FaultLog faultlog = orderService.GetFault(Id);

            return View(faultlog);
        }

        [HttpPost]
        public ActionResult UpdateFaultLog(FaultLog updatedFaultLog, string Id)
        {
            FaultLog fault = orderService.GetFault(Id);
            fault.Status = updatedFaultLog.Status;
            orderService.UpdateFault(fault);

            return RedirectToAction("Index");
        }
        // GET: FaultLogManager
        [Authorize]
        public ActionResult FaultLogForm()
        {
            Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);
            FaultLog faultLog = new FaultLog();
            faultLog.FirstName = customer.FirstName;
            faultLog.LastName = customer.LastName;
            faultLog.Email = customer.Email;
       
            return View(faultLog);
        }
        [HttpPost]
        public ActionResult FaultLogForm(FaultLog objfaultLog)
        {
            objfaultLog.Status = "Pending";
            objfaultLog.Urgency = "Unknown";
            orderService.CreateFault(objfaultLog);

            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name); //Returns the user
            string fname = customer.FirstName; //name


            string receiver = customer.Email;
            string subject = "StudentHub Fault Log Confirmation  ";
            string message = "Hi " + fname + " We have succesfully received your concern and one of our trusted technicians will be in contact soon!";

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("campuswork2021@outlook.com", "LightYear Solutions");
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

            return View();
        }
    }
}