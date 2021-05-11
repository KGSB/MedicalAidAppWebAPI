using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicalAidAppWebApi.Data
{
    public class SqlMedicationRepo : IMedicationRepo
    {
        private readonly MedicalDBContext _context;

        public SqlMedicationRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreateMedication(Medication medication)
        {
            medication.User = _context.User.FirstOrDefault(u => u.Email == medication.User.Email);
            _context.Add(medication);
        }

        public ICollection<Medication> GetMedications(string email)
            => _context.Medication.Where(m => m.User.Email == email).ToList();

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
