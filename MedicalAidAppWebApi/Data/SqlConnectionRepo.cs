using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MedicalAidAppWebApi.Data
{
    public class SqlConnectionRepo : IConnectionRepo
    {
        private readonly MedicalDBContext _context;

        public SqlConnectionRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreateConnection(Connection connection)
        {
            //neither user accessible
            ConnectionRequest request = _context.ConnectionRequests.FirstOrDefault((cr) => cr.Caretaker.Email == connection.Caretaker.Email &&
                cr.Patient.Email == connection.Patient.Email);

            //requests and both users accessible through a user
            User caretakerRequest = _context.Users.FirstOrDefault(u => u.Email == connection.Caretaker.Email);
            User patientRequest = _context.Users.FirstOrDefault(u => u.Email == connection.Patient.Email);
            
            if (request != null)
            {
                _context.ConnectionRequests.Remove(request);

                connection.CaretakerId = request.CaretakerId;
                connection.PatientId = request.PatientId;
                connection.Caretaker = caretakerRequest;
                connection.Patient = patientRequest;

                _context.Connections.Add(connection);
            }
        }

        public void DeleteConnection(Connection connection)
        {
            _context.Connections.Remove(connection);
        }

        public ICollection<Connection> GetConnections(string email)
        {
            //gets connections with the given email
            //loads caretaker and patient information for each connection
            return _context.Connections
                .Include(c => c.Caretaker)
                .Include(c => c.Patient)
                .Where(c => c.Caretaker.Email == email || c.Patient.Email == email).ToList();
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
