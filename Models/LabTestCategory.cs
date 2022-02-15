using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class LabTestCategory
    {
        public LabTestCategory()
        {
            LabAdvice = new HashSet<LabAdvice>();
        }

        public int TestCategoryId { get; set; }
        public string CategoryType { get; set; }
        public string ValueRange { get; set; }
        public string TestName { get; set; }
        public decimal LabFee { get; set; }

        public virtual ICollection<LabAdvice> LabAdvice { get; set; }
    }
}
