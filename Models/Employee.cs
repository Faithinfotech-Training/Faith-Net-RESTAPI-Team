using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Appointment = new HashSet<Appointment>();
            Prescription = new HashSet<Prescription>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
