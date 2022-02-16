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
    public class EmployeesController : ControllerBase
    {
        //data field
        private readonly IEmployeeRepository _empRepository;
        //constructor injection

        public EmployeesController(IEmployeeRepository empRepository)   //Encapsulation
        {
            _empRepository = empRepository;
        }

        #region Get All Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesAll()
        {
            return await _empRepository.GetAllEmployees();
        }

        #endregion

        #region Add an Employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeId = await _empRepository.AddEmployee(employee);
                    if (employeeId > 0)
                    {
                        return Ok(employeeId);
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

        #region Update an Employee
        [HttpPut]   //https://localhost:44377/api/employees

        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _empRepository.UpdateEmployee(employee);
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

        #region Get Employee By Id
        //Endpoint: Https://localhost:44377/api/employees/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int? id)
        {
            try
            {
                var employee = await _empRepository.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return employee;     //return Ok(employee) is also fine
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete an Employee

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var employee = await _empRepository.DeleteEmployee(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();     //return Ok(employee) is also fine
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}



    

