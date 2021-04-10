using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            Connection = new HashSet<Connection>();
            ConnectionRequest = new HashSet<ConnectionRequest>();
            Log = new HashSet<Log>();
            Medication = new HashSet<Medication>();
        }

        public uint Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Connection> Connection { get; set; }
        public virtual ICollection<ConnectionRequest> ConnectionRequest { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<Medication> Medication { get; set; }
    }
}
