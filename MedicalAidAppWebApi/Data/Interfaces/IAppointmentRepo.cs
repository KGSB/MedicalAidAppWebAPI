using MedicalAidAppWebApi.Models;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IAppointmentRepo
    {
        bool SaveChanges();
        void CreateAppointment(Appointment appointment);
        void DeleteAppointment(uint id);
        ICollection<Appointment> GetAppointments(string email);
    }
}
