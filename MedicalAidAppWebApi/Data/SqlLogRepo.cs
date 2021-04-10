using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlLogRepo : ILogRepo
    {
        private readonly MedicalDBContext _context;
        
        public SqlLogRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public ICollection<Log> GetLogs(string email) => _context.Log.Where(l => l.PatientId == _context.Patient.FirstOrDefault(p => p.Email == email).Id).ToList();
    }
}
