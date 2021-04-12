using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Dtos
{
    public class ConnectionRequestReadDto
    {
        public virtual string CaretakerName { get; set; }
        public virtual string CaretakerEmail { get; set; }
        public virtual string PatientName { get; set; }
        public virtual string PatientEmail { get; set; }
    }
}
