using Student.Core.Contracts;
using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class AppointmentManagerController : Controller
    {
        IAppointmentService appointmentService;
        IRepository<Appointment> appointments;
        IRepository<Listing> listings;

        public AppointmentManagerController(IAppointmentService AppointmentService, IRepository<Appointment> AppointmentsContext, IRepository<Listing> listingsContext)
        {
            this.appointmentService = AppointmentService;
            appointments = AppointmentsContext;
            listings = listingsContext;
        }

        // GET: ReportManager
        public ActionResult Index()
        {
            List<Appointment> appointments = appointmentService.GetAppointmentList();
            return View(appointments);
        }
        public ActionResult ViewAppointments()
        {
            List<Appointment> appointments = appointmentService.GetAppointmentList();
            return View(appointments);
        }
    }
}