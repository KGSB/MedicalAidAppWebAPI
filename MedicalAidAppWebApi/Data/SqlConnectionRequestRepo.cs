using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
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
            uint caretakerID = _context.User.FirstOrDefault(u => u.Email == connectionRequest.Caretaker.Email).Id;
            uint patientID = _context.User.FirstOrDefault(u => u.Email == connectionRequest.Patient.Email).Id;
            uint requesterID = connectionRequest.Requester.Email == connectionRequest.Patient.Email ? patientID : caretakerID;

            ConnectionRequest existingRequest = _context.ConnectionRequest
                .FirstOrDefault(cr => cr.CaretakerId == caretakerID && cr.PatientId == patientID);

            Connection existingConnection = _context.Connection
                .FirstOrDefault(c => c.CaretakerId == caretakerID && c.PatientId == patientID);

            if (existingRequest == null && existingConnection == null)
            {
                ConnectionRequest requestToAdd = new ConnectionRequest()
                {
                    CaretakerId = caretakerID,
                    PatientId = patientID,
                    RequesterId = requesterID
                };

                _context.ConnectionRequest.Add(requestToAdd);
                return requestToAdd;            
            }

            return null;
        }

        public ICollection<ConnectionRequest> GetConnectionRequests(string email)
        {
            User user = _context.User.FirstOrDefault(u => u.Email == email);
            _context.ConnectionRequest.Where(cr => cr.Caretaker.Email == email || cr.Patient.Email == email);

            //only gets requests made to the given email, doesn't get requests made by the given email
            List<ConnectionRequest> a = _context.ConnectionRequest.Where(cr => (cr.Caretaker.Email == email ||
            cr.Patient.Email == email) && cr.Requester.Email != email).ToList();

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Caretaker == null)
                {
                    a[i].Caretaker = _context.User.FirstOrDefault(u => u.Id == a[i].CaretakerId);
                }
                else if (a[i].Patient == null)
                {
                    a[i].Patient = _context.User.FirstOrDefault(u => u.Id == a[i].PatientId);
                }
            }
            //_context.ConnectionRequest.Where(cr => cr.RequesterId != user.Id &&
            //(cr.CaretakerId == user.Id || cr.PatientId == user.Id)).ToList();

            return a;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
