using MedicalAidAppWebApi.AnonymousModels;
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

        public void CreateConnectionRequest(ConnectionRequestAnonymous connectionRequest)
        {
            //get caretakerID from caretakerEmail
            //get patientID from patientEmail

            uint caretakerID = _context.Caretaker.FirstOrDefault(c => c.Email == connectionRequest.CaretakerEmail).Id;
            uint patientID = _context.Patient.FirstOrDefault(p => p.Email == connectionRequest.PatientEmail).Id;

            uint requesterID = 0;

            if (connectionRequest.RequesterEmail == connectionRequest.PatientEmail)
            {
                requesterID = patientID;
            }
            else
            {
                requesterID = caretakerID;
            }

            ConnectionRequest existingRequest =_context.ConnectionRequest.FirstOrDefault(cr => cr.PatientId == patientID && cr.CaretakerId == caretakerID && cr.RequesterId == requesterID);

            if (existingRequest == null)
            {
                _context.ConnectionRequest.Add(new ConnectionRequest()
                {
                    CaretakerId = caretakerID,
                    PatientId = patientID,
                    RequesterId = requesterID
                });
            }
        }

        public ICollection<ConnectionRequestAnonymous> GetConnectionRequests(string email)
        {
            //gets requests made to the given email
            var connectionRequests = from request in _context.ConnectionRequest
                                     join patient in _context.Patient
                                     on request.PatientId equals patient.Id
                                     join caretaker in _context.Caretaker
                                     on request.CaretakerId equals caretaker.Id
                                     where (patient.Email == email && request.RequesterId != patient.Id) ||
                                     (caretaker.Email == email && request.RequesterId != caretaker.Id)
                                     select new { patientName = patient.Name, patientEmail = patient.Email, caretakerName = caretaker.Name, caretakerEmail = caretaker.Email };
            
            List<ConnectionRequestAnonymous> connectionRequestList = new List<ConnectionRequestAnonymous>();

            foreach (var connection in connectionRequests)
            {
                connectionRequestList.Add(new ConnectionRequestAnonymous()
                {
                    CaretakerName = connection.caretakerName,
                    CaretakerEmail = connection.caretakerEmail,
                    PatientName = connection.patientName,
                    PatientEmail = connection.patientEmail
                });
            }

            return connectionRequestList;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
