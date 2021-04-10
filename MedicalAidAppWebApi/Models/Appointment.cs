using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class Appointment
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public uint? LogId { get; set; }
        public uint PatientId { get; set; }

        public virtual Log Log { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
