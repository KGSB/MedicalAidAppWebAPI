using MedicalAidAppWebApi.Models;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IConnectionRepo
    {
        bool SaveChanges();
        void CreateConnection(Connection connection);
        void DeleteConnection(Connection connection);
        ICollection<Connection> GetConnections(string email);
    }
}
