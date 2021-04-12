using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.AnonymousModels
{
    public class AppointmentAnonymous
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string PatientEmail { get; set; }
    }
}
