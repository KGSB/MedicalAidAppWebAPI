using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IPatientRepo
    {
        bool SaveChanges();
        void CreatePatient(Patient patient);
        Patient GetPatientInfo(string email);
    }
}
