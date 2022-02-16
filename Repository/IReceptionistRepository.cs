using ClinicManagementSystemv2022.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystemv2022.Repository
{
    public interface IReceptionistRepository
    {
        //Get all Patients   --SELECT --RETRIEVE
        Task<List<Patient>> GetAllPatient(); //Asynchronous

        //Add a Patient --INSERT --CREATE
        Task<int> AddPatient(Patient patient);

        //Update a Patient  --Update 
        Task UpdatePatient(Patient patient);

        //Find a Patient
        Task<ActionResult<Patient>> GetPatientById(int? id);

         //Get All Doctors
         Task<List<Doctor>> GetAllDoctors(); //Asynchronous 

        //Get All Appointments
        Task<List<Appointment>> GetAllAppointments(); //Asynchronous

        //Find an Appointment
        Task<ActionResult<Appointment>> GetAppointmentById(int? id);

        //Add an Appointment --INSERT --CREATE
        Task<int> AddAppointment(Appointment appointment);

        //Update an Appointment  --Update --Update
        Task UpdateAppointment(Appointment appointment);

        //Delete an Appointment
        Task<int> DeleteAppointment(int? id);
    }
}
