using ClinicManagementSystemv2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystemv2022.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        //data fields
        private ClinicManagementSystemContext _context;

        //Default constructor
        //Constructor based dependency injection
        public ReceptionistRepository(ClinicManagementSystemContext context)
        {
            _context = context;
        }
        #region Add Appointment
        public async Task<int> AddAppointment(Appointment appointment)
        {
            if (_context != null)
            {
                await _context.Appointment.AddAsync(appointment);
                await _context.SaveChangesAsync(); // commit the transaction
                return appointment.AppointmentId;
            }
            return 0;
        }
        #endregion

        #region Add Patient
        public async Task<int> AddPatient(Patient patient)
        {
            if (_context != null)
            {
                await _context.Patient.AddAsync(patient);
                await _context.SaveChangesAsync(); // commit the transaction
                return patient.PatientId;
            }
            return 0;
        }
        #endregion

        #region Delete Appointment
        public async Task<int> DeleteAppointment(int? id)
        {
            // Declare variable
            int result = 0;
            if (_context != null)
            {
                var appointment = await _context.Appointment.FirstOrDefaultAsync(app => app.AppointmentId == id);

                //check condition
                if (appointment != null)
                {
                    //Delete
                    _context.Appointment.Remove(appointment);

                    //commit 
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion

        #region Get All Appointments
        public async Task<List<Appointment>> GetAllAppointments()
        {
            if (_context != null)
            {
                return await _context.Appointment.ToListAsync();

            }
            return null;
        }
        #endregion

        #region Get All Doctors
        public async Task<List<Doctor>> GetAllDoctors()
        {
            if (_context != null)
            {
                return await _context.Doctor.ToListAsync();

            }
            return null;
        }
        #endregion

        #region Get All Patients
        public async Task<List<Patient>> GetAllPatient()
        {
            if (_context != null)
            {
                return await _context.Patient.ToListAsync();

            }
            return null;
        }
        #endregion

        #region Get Appointment by Id
        public async Task<ActionResult<Appointment>> GetAppointmentById(int? id)
        {
            if (_context != null)
            {
                var appointment = await _context.Appointment.FindAsync(id);   //primary key
                return appointment;
            }
            return null;
        }
        #endregion

        #region Find a Patient
        public async Task<ActionResult<Patient>> GetPatientById(int? id)
        {
            if (_context != null)
            {
                var patient = await _context.Patient.FindAsync(id);   //primary key
                return patient;
            }
            return null;
        }
        #endregion

        #region Update Appointment
        public async Task UpdateAppointment(Appointment appointment)
        {
            if (_context != null)
            {
                _context.Entry(appointment).State = EntityState.Modified;
                _context.Appointment.Update(appointment);
                await _context.SaveChangesAsync(); // commit the transaction

            }
        }
        #endregion

        #region Update Patient
        public async Task UpdatePatient(Patient patient)
        {
            if (_context != null)
            {
                _context.Entry(patient).State = EntityState.Modified;
                _context.Patient.Update(patient);
                await _context.SaveChangesAsync(); // commit the transaction

            }
        }
        #endregion
    }
}
