using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementSystemv2022.Models;
using ClinicManagementSystemv2022.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystemv2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistsController : ControllerBase
    {
        //data field
        private readonly IPharmacistRepository _medRepository;
        //constructor injection

        public PharmacistsController(IPharmacistRepository medRepository)   //Encapsulation
        {
            _medRepository = medRepository;
        }

        #region Get All Medicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicinesAll()
        {
            return await _medRepository.GetAllMedicines();
        }

        #endregion

        #region Add a Medicine
        [HttpPost]
        public async Task<IActionResult> AddMedicine([FromBody] Medicine medicine)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var medicineId = await _medRepository.AddMedicine(medicine);
                    if (medicineId > 0)
                    {
                        return Ok(medicineId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region Update a Medicine
        [HttpPut]   //https://localhost:44377/api/medicines

        public async Task<IActionResult> UpdateMedicine([FromBody] Medicine medicine)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _medRepository.UpdateMedicine(medicine);
                    return Ok();
                }

                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Get Medicine By Id
        //Endpoint: Https://localhost:44377/api/medicines/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetMedicineById(int? id)
        {
            try
            {
                var medicine = await _medRepository.GetMedicineById(id);
                if (medicine == null)
                {
                    return NotFound();
                }
                return medicine;     //return Ok(medicine) is also fine
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete a Medicine

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicineById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var employee = await _medRepository.DeleteMedicine(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();     //return Ok(medicine) is also fine
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
