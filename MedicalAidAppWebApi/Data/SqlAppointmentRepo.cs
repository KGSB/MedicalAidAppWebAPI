using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using Microsoft.EntityFrameworkCore;
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
            appointment.User = _context.Users.FirstOrDefault(u => u.Email == appointment.User.Email);
            appointment.UserId = appointment.User.Id;
            _context.Add(appointment);
        }

        public void DeleteAppointment(uint id)
        {
            Appointment appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
            _context.Appointments.Remove(appointment);
        }

        public ICollection<Appointment> GetAppointments(string email)
        {
            return _context.Appointments
                .Where(a => a.User.Email == email)
                .Include(appointment => appointment.User)
                .ToList();
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
