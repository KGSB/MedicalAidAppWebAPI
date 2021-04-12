using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Dtos
{
    public class ConnectionCreateDto
    {
        public string CaretakerEmail { get; set; }
        public string PatientEmail { get; set; }
        //the email of the person accepting the connection, required for CreatedAtRoute() routeValue.
        public string AccepterEmail { get; set; }
    }
}
