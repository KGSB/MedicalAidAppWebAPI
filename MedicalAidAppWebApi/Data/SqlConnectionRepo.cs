using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlConnectionRepo : IConnectionRepo
    {
        private readonly MedicalDBContext _context;

        public SqlConnectionRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public ICollection<Tuple<string, string>> GetConnections(string email)
        {
            var connections = from connection in _context.Connection
                              join patient in _context.Patient
                              on connection.PatientId equals patient.Id
                              join caretaker in _context.Caretaker
                              on connection.CaretakerId equals caretaker.Id
                              where patient.Email == email || caretaker.Email == email
                              select new { patientName = patient.Name,
                              caretakerName = caretaker.Name };

            //conversion from anonymous type. try to find a way to select into a non-anonymous type
            //try to find a way to connect this to a DTO. Is a DTO here even necessary?
            List<Tuple<string, string>> connectionList = new List<Tuple<string, string>>();

            foreach (var connection in connections)
            {
                connectionList.Add(new Tuple<string, string>(connection.patientName, connection.caretakerName));
            }

            return connectionList;
        }
    }
}
