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

        public ICollection<Appointment> GetAppointments(string email)
            => _context.Appointment.Where(a => a.User.Email == email).ToList();

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
