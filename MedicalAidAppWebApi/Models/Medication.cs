using System;
using System.Collections.Generic;

#nullable disable

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
