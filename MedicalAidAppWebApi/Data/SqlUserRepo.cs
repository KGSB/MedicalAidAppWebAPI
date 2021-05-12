using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly MedicalDBContext _context;

        public SqlUserRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(string email)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == email);

            foreach (Connection connection in _context.Connections.Where(c => c.Caretaker == user || c.Patient == user))
            {
                _context.Connections.Remove(connection);
            }

            foreach (ConnectionRequest connectionRequest in _context.ConnectionRequests.Where(cr => cr.Caretaker == user || cr.Patient == user))
            {
                _context.ConnectionRequests.Remove(connectionRequest);
            }

            foreach (Medication medication in _context.Medications.Where(m => m.User == user))
            {
                _context.Medications.Remove(medication);
            }

            foreach (Log log in _context.Logs.Where(l => l.User == user))
            {
                _context.Logs.Remove(log);
            }

            foreach (Appointment appointment in _context.Appointments.Where(a => a.User == user))
            {
                _context.Appointments.Remove(appointment);
            }

            _context.Users.Remove(user);
        }

        public User GetUserInfo(string email) => _context.Users.FirstOrDefault(u => u.Email == email);       

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
