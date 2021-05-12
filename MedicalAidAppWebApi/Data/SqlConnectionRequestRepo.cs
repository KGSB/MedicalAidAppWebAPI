using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MedicalAidAppWebApi.Data
{
    public class SqlConnectionRequestRepo : IConnectionRequestRepo
    {
        private readonly MedicalDBContext _context;

        public SqlConnectionRequestRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public ConnectionRequest CreateConnectionRequest(ConnectionRequest connectionRequest)
        {
            uint caretakerID = _context.Users.FirstOrDefault(u => u.Email == connectionRequest.Caretaker.Email).Id;
            uint patientID = _context.Users.FirstOrDefault(u => u.Email == connectionRequest.Patient.Email).Id;
            uint requesterID = connectionRequest.Requester.Email == connectionRequest.Patient.Email ? patientID : caretakerID;

            ConnectionRequest existingRequest = _context.ConnectionRequests
                .FirstOrDefault(cr => cr.CaretakerId == caretakerID && cr.PatientId == patientID);

            Connection existingConnection = _context.Connections
                .FirstOrDefault(c => c.CaretakerId == caretakerID && c.PatientId == patientID);

            if (existingRequest == null && existingConnection == null)
            {
                ConnectionRequest requestToAdd = new ConnectionRequest()
                {
                    CaretakerId = caretakerID,
                    PatientId = patientID,
                    RequesterId = requesterID
                };

                _context.ConnectionRequests.Add(requestToAdd);
                return requestToAdd;            
            }

            return null;
        }

        public void DeleteConnectionRequest(ConnectionRequest connectionRequest)
        {
            _context.ConnectionRequests.Remove(connectionRequest);
        }

        public ICollection<ConnectionRequest> GetConnectionRequests(string email)
        {
            //only gets requests made to the given email, doesn't get requests made by the given email
            //loads caretaker and patient information for each request that matches our condition
            return _context.ConnectionRequests
                .Include(cr => cr.Caretaker)
                .Include(cr => cr.Patient)
                .Where(cr => (cr.Caretaker.Email == email || cr.Patient.Email == email) && cr.Requester.Email != email).ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
