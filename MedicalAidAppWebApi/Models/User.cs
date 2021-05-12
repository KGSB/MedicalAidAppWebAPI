using System;
using System.Collections.Generic;

#nullable disable

namespace MedicalAidAppWebApi.Models
{
    public partial class User
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();
            ConnectionCaretakers = new HashSet<Connection>();
            ConnectionPatients = new HashSet<Connection>();
            ConnectionRequestCaretakers = new HashSet<ConnectionRequest>();
            ConnectionRequestPatients = new HashSet<ConnectionRequest>();
            ConnectionRequestRequesters = new HashSet<ConnectionRequest>();
            Logs = new HashSet<Log>();
            Medications = new HashSet<Medication>();
        }

        public uint Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPatient { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Connection> ConnectionCaretakers { get; set; }
        public virtual ICollection<Connection> ConnectionPatients { get; set; }
        public virtual ICollection<ConnectionRequest> ConnectionRequestCaretakers { get; set; }
        public virtual ICollection<ConnectionRequest> ConnectionRequestPatients { get; set; }
        public virtual ICollection<ConnectionRequest> ConnectionRequestRequesters { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
    }
}
