using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class MedicinePrescription
    {
        public int PrescriptionMedId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? MedicineId { get; set; }
        public string Dosage { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
