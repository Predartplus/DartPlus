using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DartPlusAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly PlusDbContext _context;

        public PatientService(PlusDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<object>> AddPatient(Patients Patient)
        {
            _context.Patients.Add(Patient);
            return await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<object>> DeletePatient(Guid id)
        {
            try
            {
                Patients RemovePatients = await _context.Patients.FindAsync(id);
                _context.Patients.Remove(RemovePatients);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<ActionResult<object>> GetPatient(Guid id)
        {
            try
            {
                return await _context.Patients.FirstOrDefaultAsync(u => u.PatientID == id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<ActionResult<object>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<ActionResult<object>> UpdatePatient(Guid id, Patients Patient)
        {
            try
            {
                Patients patients = await _context.Patients.FirstOrDefaultAsync(u => u.PatientID == id);

                patients.PatientName = Patient.PatientName;
                //patients.AddressID = Patient.name;
                patients.PatientDateOfBirth = Patient.PatientDateOfBirth;
                patients.PatientGender = Patient.PatientGender;
                patients.PatientPhoneNumber = Patient.PatientPhoneNumber;
                patients.PatientEmail = Patient.PatientEmail;
                patients.PatientMaritalStatus = Patient.PatientMaritalStatus;
                patients.BloodGroupID = Patient.BloodGroupID;
                patients.InsuranceProvider = Patient.InsuranceProvider;
                patients.InsurancePolicyNumber = Patient.InsurancePolicyNumber;
                patients.UpdatedBy = Patient.UpdatedBy;
                patients.UpdatedOn = Patient.UpdatedOn;

                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
