using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Dtos
{
    public class MedicationCreateUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dosage { get; set; }
        public string Time { get; set; }
        public string PatientEmail { get; set; }
    }
}
