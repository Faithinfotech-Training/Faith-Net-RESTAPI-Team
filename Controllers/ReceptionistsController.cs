using ClinicManagementSystemv2022.Models;
using ClinicManagementSystemv2022.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystemv2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistsController : ControllerBase
    {
        //data field
        private readonly IReceptionistRepository _recRepository;

        //constructor injection
        public ReceptionistsController(IReceptionistRepository recRepository)   //Encapsulation
        {
            _recRepository = recRepository;
        }

        #region Get All Patients 
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientAll()
        {
            return await _recRepository.GetAllPatient();
        }
        #endregion

        #region Add a Patient
        [HttpPost("patient")]   //https://localhost:44383/api/receptionists/patient
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var patientId = await _recRepository.AddPatient(patient);
                    if (patientId > 0)
                    {
                        return Ok(patientId);
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

        #region Update a Patient
        [HttpPut("patient")] // https://localhost:44383/api/receptionists/patient

        public async Task<IActionResult> UpdatePatient([FromBody] Patient patient)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _recRepository.UpdatePatient(patient);
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

        #region Get Patient By Id
        //Endpoint: Https://localhost:44377/api/
        [HttpGet("patient/patientid")]
        public async Task<ActionResult<Patient>> GetPatientById(int? id)
        {
            try
            {
                var patientid = await _recRepository.GetPatientById(id);
                if (patientid == null)
                {
                    return NotFound();
                }
                return patientid;     //return Ok(patientid) is also fine
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

                 #region Get All Doctors 
                    [HttpGet("doctor")]
       
                public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorsAll()
                {
                    return await _recRepository.GetAllDoctors();
                }
                #endregion
        
        #region Add an Appointment
        [HttpPost("appointment")]
        public async Task<IActionResult> AddAppointment([FromBody] Appointment appointment)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var appointmentId = await _recRepository.AddAppointment(appointment);
                    if (appointmentId > 0)
                    {
                        return Ok(appointmentId);
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

        #region Update an Appointment
        [HttpPut("appointment")] // https://localhost:44383/api/receptionists/appointment

        public async Task<IActionResult> UpdateAppointment([FromBody] Appointment appointment)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _recRepository.UpdateAppointment(appointment);
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



    }
}
