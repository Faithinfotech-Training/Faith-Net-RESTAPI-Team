using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal AppointmentFee { get; set; }

        public virtual Employee Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
