using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            LabAdvice = new HashSet<LabAdvice>();
            MedicinePrescription = new HashSet<MedicinePrescription>();
        }

        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public virtual Employee Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<LabAdvice> LabAdvice { get; set; }
        public virtual ICollection<MedicinePrescription> MedicinePrescription { get; set; }
    }
}
