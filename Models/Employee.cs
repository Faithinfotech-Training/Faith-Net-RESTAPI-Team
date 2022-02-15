using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Contact { get; set; }
        public string Department { get; set; }
        public int? DepartmentId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Department DepartmentNavigation { get; set; }
    }
}
