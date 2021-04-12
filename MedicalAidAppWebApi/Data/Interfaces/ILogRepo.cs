using MedicalAidAppWebApi.AnonymousModels;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface ILogRepo
    {
        bool SaveChanges();
        void CreateLog(LogAnonymous log);
        ICollection<Log> GetLogs(string email);
    }
}
