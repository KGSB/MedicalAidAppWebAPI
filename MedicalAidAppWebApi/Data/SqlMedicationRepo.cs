using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using Microsoft.EntityFrameworkCore;
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
            medication.User = _context.Users.FirstOrDefault(u => u.Email == medication.User.Email);
            _context.Add(medication);
        }

        public void DeleteMedication(uint mediactionId)
        {
            Medication medication = _context.Medications.FirstOrDefault(m => m.Id == mediactionId);
            _context.Medications.Remove(medication);
        }

        public ICollection<Medication> GetMedications(string email)
        {
            return _context.Medications
                .Where(m => m.User.Email == email)
                .Include(m => m.User)
                .ToList();
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
