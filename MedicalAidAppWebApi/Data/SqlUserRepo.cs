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
            _context.User.Add(user);
        }

        public void DeleteUser(string email)
        {
            User user = _context.User.FirstOrDefault(u => u.Email == email);

            foreach (Connection connection in _context.Connection.Where(c => c.Caretaker == user || c.Patient == user))
            {
                _context.Connection.Remove(connection);
            }

            foreach (ConnectionRequest connectionRequest in _context.ConnectionRequest.Where(cr => cr.Caretaker == user || cr.Patient == user))
            {
                _context.ConnectionRequest.Remove(connectionRequest);
            }

            foreach (Medication medication in _context.Medication.Where(m => m.User == user))
            {
                _context.Medication.Remove(medication);
            }

            foreach (Log log in _context.Log.Where(l => l.User == user))
            {
                _context.Log.Remove(log);
            }

            foreach (Appointment appointment in _context.Appointment.Where(a => a.User == user))
            {
                _context.Appointment.Remove(appointment);
            }

            _context.User.Remove(user);
        }

        public User GetUserInfo(string email) => _context.User.FirstOrDefault(u => u.Email == email);       

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
