using ClinicManagementSystemv2022.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystemv2022.Repository
{
   public  interface IEmployeeRepository
    {
        //only declarations--Abstraction

        //Get all Employees     --SELECT ---RETRIEVE
        //all the data should be accepted in Asynchronous manner--async -await - Promise
        Task<List<Employee>> GetAllEmployees();  //Asynchronous       

        //Add an Employee---INSERT ---CREATE
        Task<int> AddEmployee(Employee employee);

        //Update an Employee   ---UPDATE   --UPDATE
        Task UpdateEmployee(Employee employee);

        //Find an Employee
        Task<ActionResult<Employee>> GetEmployeeById(int? id);

        //Delete an Employee
        Task<int> DeleteEmployee(int? id);
    }
}
    

