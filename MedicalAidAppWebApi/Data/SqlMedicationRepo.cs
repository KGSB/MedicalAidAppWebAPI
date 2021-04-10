using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlMedicationRepo : IMedicationRepo
    {
        private readonly MedicalDBContext _context;

        public SqlMedicationRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public ICollection<Medication> GetMedications(string email) => _context.Medication.Where(m => m.PatientId == _context.Patient.FirstOrDefault(p => p.Email == email).Id).ToList();
    }
}
