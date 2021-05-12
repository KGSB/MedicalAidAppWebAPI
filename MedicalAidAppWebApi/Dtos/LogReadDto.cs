using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Dtos
{
    public class LogReadDto
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? PainScale { get; set; }
    }
}
