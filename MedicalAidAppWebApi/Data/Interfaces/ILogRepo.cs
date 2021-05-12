using MedicalAidAppWebApi.Models;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface ILogRepo
    {
        bool SaveChanges();
        void CreateLog(Log log);
        void DeleteLog(uint id);
        ICollection<Log> GetLogs(string email);
    }
}
