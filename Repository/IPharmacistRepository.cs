using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementSystemv2022.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystemv2022.Repository
{
    public interface IPharmacistRepository
    {
        //only declarations--Abstraction

        //Get all Medicines     --SELECT ---RETRIEVE
        //all the data should be accepted in Asynchronous manner--async -await - Promise
        Task<List<Medicine>> GetAllMedicines();  //Asynchronous       

        //Add a Medicine---INSERT ---CREATE
        Task<int> AddMedicine(Medicine medicine);

        //Update a Medicine   ---UPDATE   --UPDATE
        Task UpdateMedicine(Medicine medicine);

        //Find a Medicine
        Task<ActionResult<Medicine>> GetMedicineById(int? id);

        //Delete a Medicine
        Task<int> DeleteMedicine(int? id);
    }
}
