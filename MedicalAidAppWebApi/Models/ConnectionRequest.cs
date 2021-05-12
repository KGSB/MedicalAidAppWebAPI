using System;
using System.Collections.Generic;

#nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class ConnectionRequest
    {
        public uint Id { get; set; }
        public uint CaretakerId { get; set; }
        public uint PatientId { get; set; }
        public uint RequesterId { get; set; }

        public virtual User Caretaker { get; set; }
        public virtual User Patient { get; set; }
        public virtual User Requester { get; set; }
    }
}
