using System;
using Student.Core.Models;
using Student.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Services
{
    public class AppointmentService : IAppointmentService
    {
        IRepository<Appointment> appointmentContext;
        IRepository<Listing> listingContext;

        public AppointmentService(IRepository<Appointment> AppointmentContext, IRepository<Listing> ListingContext)
        {
            this.appointmentContext = AppointmentContext;
            this.listingContext = ListingContext;
        }

        public void CreateAppointment(Appointment baseAppointment)
        {
            //Code to update number of reports for an area
            string StudentName = "";
            string listingId = "";

            //Listing listing = listingContext.Collection().Where(a => a.ListingId.ToString() == reportedArea).FirstOrDefault();
            //repId = area.Id;

            //Area areaToEdit = areaContext.Find(repId);
            //areaToEdit.NumReports += 1;
            //areaContext.Commit();


            appointmentContext.Insert(baseAppointment);
            appointmentContext.Commit();
        }

        public List<Appointment> GetAppointmentList() //Returns list of Appointments
        {
            return appointmentContext.Collection().ToList();
        }

        public Appointment GetAppointment(string Id) //Returns an individual Appointment
        {
            return appointmentContext.Find(Id);
        }

        public void UpdateAppointment(Appointment updatedAppointment) //Updates Appointment
        {
            appointmentContext.Update(updatedAppointment);
            appointmentContext.Commit();
        }

    }
}
