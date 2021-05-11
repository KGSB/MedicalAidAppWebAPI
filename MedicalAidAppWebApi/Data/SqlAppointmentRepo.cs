using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicalAidAppWebApi.Data
{
    public class SqlAppointmentRepo : IAppointmentRepo
    {
        private readonly MedicalDBContext _context;

        public SqlAppointmentRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreateAppointment(Appointment appointment)
        {
            appointment.User = _context.User.FirstOrDefault(u => u.Email == appointment.User.Email);
            appointment.UserId = appointment.User.Id;
            _context.Appointment.Add(appointment);
        }

        public void DeleteAppointment(uint id)
        {
            Appointment appointment = _context.Appointment.FirstOrDefault(a => a.Id == id);
            _context.Appointment.Remove(appointment);
        }

        public ICollection<Appointment> GetAppointments(string email)
        {
            var appointments = _context.Appointment.Where(a => a.User.Email == email);

            //explicitly load the user information attatched to the appointments
            //necessary for patching
            foreach (var appointment in appointments)
            {
                //_context.Entry(appointment).Reference(a => a.User).Load();
            }

            //var appointmentList = appointments.ToList();
            return appointments.ToList();
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
