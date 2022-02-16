using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementSystemv2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystemv2022.Repository
{
    public class PharmacistRepository : IPharmacistRepository
    {
        //Data fields
        private readonly ClinicManagementSystemContext _context;

        //Default Constructor
        //Constructor based dependency injection
        public PharmacistRepository(ClinicManagementSystemContext context)
        {
            _context = context;
        }

        #region Get All Medicines
        public async Task<List<Medicine>> GetAllMedicines()
        {
            if (_context != null)
            {
                return await _context.Medicine.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add Medicine
        public async Task<int> AddMedicine(Medicine medicine)
        {
            if (_context != null)
            {
                await _context.Medicine.AddAsync(medicine);
                await _context.SaveChangesAsync(); // commit the transaction
                return medicine.MedicineId;
            }
            return 0;
        }
        #endregion

        #region Update a Medicine
        public async Task UpdateMedicine(Medicine medicine)
        {
            if (_context != null)
            {
                _context.Entry(medicine).State = EntityState.Modified;
                _context.Medicine.Update(medicine);
                await _context.SaveChangesAsync();  //commit the transaction  
            }
        }
        #endregion

        #region Get Medicine By id
        public async Task<ActionResult<Medicine>> GetMedicineById(int? id)
        {
            if (_context != null)
            {
                var medicine = await _context.Medicine.FindAsync(id);   //primary key
                return medicine;
            }
            return null;
        }
        #endregion

        #region Delete a Medicine
        public async Task<int> DeleteMedicine(int? id)
        {
            //Declare variable
            int result = 0;
            if (_context != null)
            {
                var medicine = await _context.Medicine.FirstOrDefaultAsync(med => med.MedicineId == id);

                //check condition
                if (medicine != null)
                {
                    //Delete
                    _context.Medicine.Remove(medicine);

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
