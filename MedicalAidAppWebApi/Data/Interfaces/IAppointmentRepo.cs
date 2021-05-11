using MedicalAidAppWebApi.Models;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IAppointmentRepo
    {
        bool SaveChanges();
        void CreateAppointment(Appointment appointment);
        ICollection<Appointment> GetAppointments(string email);
    }
}
