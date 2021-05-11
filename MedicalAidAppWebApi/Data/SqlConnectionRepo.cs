using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
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
            ConnectionRequest request = _context.ConnectionRequest.FirstOrDefault((cr) => cr.Caretaker.Email == connection.Caretaker.Email &&
                cr.Patient.Email == connection.Patient.Email);

            //requests and both users accessible through a user
            User caretakerRequest = _context.User.FirstOrDefault(u => u.Email == connection.Caretaker.Email);
            User patientRequest = _context.User.FirstOrDefault(u => u.Email == connection.Patient.Email);
            
            if (request != null)
            {
                _context.ConnectionRequest.Remove(request);

                connection.CaretakerId = request.CaretakerId;
                connection.PatientId = request.PatientId;
                connection.Caretaker = caretakerRequest;
                connection.Patient = patientRequest;

                _context.Connection.Add(connection);
            }
        }

        public ICollection<Connection> GetConnections(string email)
        {
            User user = _context.User.FirstOrDefault(u => u.Email == email);

            //ConnectionCaretaker is null if the user is a caretaker, ConnectionPatient is null if the user is patient
            if (user.ConnectionCaretaker != null)
                return user.ConnectionCaretaker;
            else
                return user.ConnectionPatient;
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
