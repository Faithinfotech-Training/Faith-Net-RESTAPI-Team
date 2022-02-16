using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int? PatientId { get; set; }
        public decimal? MedicineFee { get; set; }
        public decimal? LabFee { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
