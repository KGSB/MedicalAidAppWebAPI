using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
