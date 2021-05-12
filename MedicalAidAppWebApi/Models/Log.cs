using System;
using System.Collections.Generic;

#nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class Log
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? Painscale { get; set; }
        public uint UserId { get; set; }

        public virtual User User { get; set; }
    }
}
