using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class Medication
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dosage { get; set; }
        public string Time { get; set; }
        public uint UserId { get; set; }

        public virtual User User { get; set; }
    }
}
