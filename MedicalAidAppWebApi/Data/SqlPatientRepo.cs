using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlPatientRepo : IPatientRepo
    {
        private readonly MedicalDBContext _context;

        public SqlPatientRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreatePatient(Patient patient)
        {
            _context.Patient.Add(patient);
        }

        public Patient GetPatientInfo(string email) => _context.Patient.FirstOrDefault(p => p.Email == email);

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
