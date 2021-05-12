using System;
using System.Collections.Generic;

#nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class Connection
    {
        public uint Id { get; set; }
        public uint CaretakerId { get; set; }
        public uint PatientId { get; set; }

        public virtual User Caretaker { get; set; }
        public virtual User Patient { get; set; }
    }
}
