using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Dtos
{
    public class ConnectionReadDto
    {
        public virtual Caretaker Caretaker { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
