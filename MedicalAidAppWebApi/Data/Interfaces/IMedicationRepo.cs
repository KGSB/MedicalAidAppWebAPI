using MedicalAidAppWebApi.AnonymousModels;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IMedicationRepo
    {
        bool SaveChanges();
        void CreateMedication(MedicationAnonymous medication);
        ICollection<Medication> GetMedications(string email);
    }
}
