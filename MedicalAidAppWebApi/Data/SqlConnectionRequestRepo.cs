using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlConnectionRequestRepo : IConnectionRequestRepo
    {
        private readonly MedicalDBContext _context;

        public SqlConnectionRequestRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public ICollection<Tuple<string, string>> GetConnectionRequests(string email)
        {
            //gets requests made to the given email
            var connectionRequests = from request in _context.ConnectionRequest
                                     join patient in _context.Patient
                                     on request.PatientId equals patient.Id
                                     join caretaker in _context.Caretaker
                                     on request.CaretakerId equals caretaker.Id
                                     where (patient.Email == email && request.RequesterId != patient.Id) ||
                                     (caretaker.Email == email && request.RequesterId != caretaker.Id)
                                     select new { patientName = patient.Name, caretakerName = caretaker.Name };
            
            List<Tuple<string, string>> connectionRequestList = new List<Tuple<string, string>>();

            foreach (var connection in connectionRequests)
            {
                connectionRequestList.Add(new Tuple<string, string>(connection.patientName, connection.caretakerName));
            }

            return connectionRequestList;
        }
    }
}
