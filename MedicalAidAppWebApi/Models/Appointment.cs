using System;
using System.Collections.Generic;

#nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class Appointment
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public uint UserId { get; set; }

        public virtual User User { get; set; }
    }
}
