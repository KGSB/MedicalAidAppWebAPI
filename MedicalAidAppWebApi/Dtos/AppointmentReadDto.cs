using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Dtos
{
    public class AppointmentReadDto
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
    }
}
