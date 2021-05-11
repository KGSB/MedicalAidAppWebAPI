using MedicalAidAppWebApi.Models;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IConnectionRequestRepo
    {
        bool SaveChanges();
        ConnectionRequest CreateConnectionRequest(ConnectionRequest connectionRequest);
        ICollection<ConnectionRequest> GetConnectionRequests(string email);
    }
}
