using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using Microsoft.EntityFrameworkCore;
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
            log.User = _context.Users.FirstOrDefault(u => u.Email == log.User.Email);
            _context.Logs.Add(log);
        }

        public void DeleteLog(uint id)
        {
            Log log = _context.Logs.FirstOrDefault(l => l.Id == id);
            _context.Logs.Remove(log);
        }

        public ICollection<Log> GetLogs(string email)
        {
            return _context.Logs.Where(l => l.User.Email == email)
                .Include(l => l.User)
                .ToList();
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
