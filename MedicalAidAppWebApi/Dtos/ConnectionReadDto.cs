using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Dtos
{
    public class ConnectionReadDto
    {
        public virtual string CaretakerEmail { get; set; }
        public virtual string PatientEmail { get; set; }
    }
}
