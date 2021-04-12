using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.AnonymousModels
{
    public class LogAnonymous
    {
        public string PatientEmail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? PainScale { get; set; }
    }
}
