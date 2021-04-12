using MedicalAidAppWebApi.AnonymousModels;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IAppointmentRepo
    {
        bool SaveChanges();
        void CreateAppointment(AppointmentAnonymous appointment);
        ICollection<Appointment> GetAppointments(string email);
    }
}
