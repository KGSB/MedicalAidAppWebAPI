using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class User
    {
        public User()
        {
            Appointment = new HashSet<Appointment>();
            ConnectionCaretaker = new HashSet<Connection>();
            ConnectionPatient = new HashSet<Connection>();
            ConnectionRequestCaretaker = new HashSet<ConnectionRequest>();
            ConnectionRequestPatient = new HashSet<ConnectionRequest>();
            ConnectionRequestRequester = new HashSet<ConnectionRequest>();
            Log = new HashSet<Log>();
            Medication = new HashSet<Medication>();
        }

        public uint Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPatient { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Connection> ConnectionCaretaker { get; set; }
        public virtual ICollection<Connection> ConnectionPatient { get; set; }
        public virtual ICollection<ConnectionRequest> ConnectionRequestCaretaker { get; set; }
        public virtual ICollection<ConnectionRequest> ConnectionRequestPatient { get; set; }
        public virtual ICollection<ConnectionRequest> ConnectionRequestRequester { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<Medication> Medication { get; set; }
    }
}
