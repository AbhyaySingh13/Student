using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Contracts
{
   public interface IAppointmentService 
    {
        void CreateAppointment(Appointment baseAppointment);

        List<Appointment> GetAppointmentList();
        Appointment GetAppointment(string Id);
        void UpdateAppointment(Appointment updatedAppointment);
    }
}
