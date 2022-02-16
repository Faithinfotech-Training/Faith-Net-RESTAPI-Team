using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            MedicinePrescription = new HashSet<MedicinePrescription>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public decimal MedicineCharge { get; set; }

        public virtual ICollection<MedicinePrescription> MedicinePrescription { get; set; }
    }
}
