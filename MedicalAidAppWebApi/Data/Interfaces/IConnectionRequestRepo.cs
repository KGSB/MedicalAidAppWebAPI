using MedicalAidAppWebApi.AnonymousModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IConnectionRequestRepo
    {
        bool SaveChanges();
        void CreateConnectionRequest(ConnectionRequestAnonymous connectionRequest);
        ICollection<ConnectionRequestAnonymous> GetConnectionRequests(string email);
    }
}
