using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class Doctor
    {
        public int? DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DeptName { get; set; }
        public string IsActive { get; set; }

        public virtual Employee DoctorNavigation { get; set; }
    }
}
