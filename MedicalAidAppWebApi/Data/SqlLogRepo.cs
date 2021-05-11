using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicalAidAppWebApi.Data
{
    public class SqlLogRepo : ILogRepo
    {
        private readonly MedicalDBContext _context;
        
        public SqlLogRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreateLog(Log log)
        {
            log.User = _context.User.FirstOrDefault(u => u.Email == log.User.Email);
            _context.Log.Add(log);
        }

        public ICollection<Log> GetLogs(string email)
            => _context.Log.Where(l => l.User.Email == email).ToList();

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
