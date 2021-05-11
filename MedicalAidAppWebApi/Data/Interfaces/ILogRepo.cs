using MedicalAidAppWebApi.Models;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface ILogRepo
    {
        bool SaveChanges();
        void CreateLog(Log log);
        ICollection<Log> GetLogs(string email);
    }
}
