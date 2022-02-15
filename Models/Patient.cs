using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            Bill = new HashSet<Bill>();
            Prescription = new HashSet<Prescription>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
