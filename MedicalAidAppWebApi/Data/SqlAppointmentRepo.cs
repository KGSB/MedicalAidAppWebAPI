using MedicalAidAppWebApi.AnonymousModels;
using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlAppointmentRepo : IAppointmentRepo
    {
        private readonly MedicalDBContext _context;

        public SqlAppointmentRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreateAppointment(AppointmentAnonymous appointment)
        {
            uint patientID = _context.Patient.FirstOrDefault(p => p.Email == appointment.PatientEmail).Id;

            _context.Appointment.Add(new Appointment()
            {
                DateTime = appointment.DateTime,
                Description = appointment.Description,
                Title = appointment.Title,
                PatientId = patientID,
            });
        }

        public ICollection<Appointment> GetAppointments(string email) => _context.Appointment.Where(a => a.PatientId == _context.Patient.FirstOrDefault(p => p.Email == email).Id).ToList();

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
