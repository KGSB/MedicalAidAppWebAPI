using MedicalAidAppWebApi.Models;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IMedicationRepo
    {
        bool SaveChanges();
        void CreateMedication(Medication medication);
        void DeleteMedication(uint mediactionId);
        ICollection<Medication> GetMedications(string email);
    }
}
