using MedicalAidAppWebApi.AnonymousModels;
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

        public void CreateLog(LogAnonymous log)
        {
            uint patientID = _context.Patient.FirstOrDefault(p => p.Email == log.PatientEmail).Id;

            _context.Log.Add(new Log()
            {
                Description = log.Description,
                Title = log.Title,
                PatientId = patientID,
                PainScale = log.PainScale
            });
        }

        public ICollection<Log> GetLogs(string email) => _context.Log.Where(l => l.PatientId == _context.Patient.FirstOrDefault(p => p.Email == email).Id).ToList();

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
