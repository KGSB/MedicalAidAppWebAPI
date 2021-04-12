using MedicalAidAppWebApi.AnonymousModels;
using MedicalAidAppWebApi.Dtos;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IConnectionRepo
    {
        bool SaveChanges();
        void CreateConnection(ConnectionAnonymous connection);
        ICollection<ConnectionAnonymous> GetConnections(string email);
    }
}
