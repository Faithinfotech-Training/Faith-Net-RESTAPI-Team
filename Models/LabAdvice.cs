using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class LabAdvice
    {
        public int LabTestId { get; set; }
        public int? TestCategoryId { get; set; }
        public int? PrescriptionId { get; set; }

        public virtual Prescription Prescription { get; set; }
        public virtual LabTestCategory TestCategory { get; set; }
    }
}
