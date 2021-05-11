using MedicalAidAppWebApi.Models;
using System.Collections.Generic;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IMedicationRepo
    {
        bool SaveChanges();
        void CreateMedication(Medication medication);
        ICollection<Medication> GetMedications(string email);
    }
}
