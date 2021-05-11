using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Dtos
{
    public class ConnectionRequestCreateDto
    {
        public string CaretakerEmail { get; set; }
        public string PatientEmail { get; set; }
        public string RequesterEmail { get; set; }
    }
}