using ClinicManagementSystemv2022.Models;
using ClinicManagementSystemv2022.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CMSV2022.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //Data fields
        private readonly ClinicManagementSystemContext _context;

        //Default Constructor
        //Constructor based dependency injection
        public EmployeeRepository(ClinicManagementSystemContext context)
        {
            _context = context;
        }

        #region Get All Employees
        public async Task<List<Employee>> GetAllEmployees()
        {
            if (_context != null)
            {
                return await _context.Employee.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add Employee
        public async Task<int> AddEmployee(Employee employee)
        {
            if (_context != null)
            {
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync(); // commit the transaction
                return employee.EmployeeId;
            }
            return 0;
        }
        #endregion

        #region Update an Employee
        public async Task UpdateEmployee(Employee employee)
        {
            if (_context != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();  //commit the transaction  
            }
        }
        #endregion

        #region Get Employee By id
        public async Task<ActionResult<Employee>> GetEmployeeById(int? id)
        {
            if (_context != null)
            {
                var employee = await _context.Employee.FindAsync(id);   //primary key
                return employee;
            }
            return null;
        }
        #endregion

        #region Delete an Employee
        public async Task<int> DeleteEmployee(int? id)
        {
            //Declare variable
            int result = 0;
            if (_context != null)
            {
                var employee = await _context.Employee.FirstOrDefaultAsync(emp => emp.EmployeeId == id);

                //check condition
                if (employee != null)
                {
                    //Delete
                    _context.Employee.Remove(employee);

                    //commit 
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion
    }
}
