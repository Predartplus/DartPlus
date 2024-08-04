using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DartPlusAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly PlusDbContext _context;

        public AppointmentService(PlusDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<object>> AddAppointment(Appointment Appointment)
        {
            _context.Appointment.Add(Appointment);
            return await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<object>> DeleteAppointment(Guid id)
        {
            try
            {
                Appointment RemoveAppointment = await _context.Appointment.FindAsync(id);
                _context.Appointment.Remove(RemoveAppointment);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<ActionResult<object>> GetAppointment(Guid id)
        {
            try
            {
                return await _context.Appointment.FirstOrDefaultAsync(u => u.AppointmentID == id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<ActionResult<object>> GetAppointmentList()
        {
            return await _context.Appointment.ToListAsync();
        }

        public async Task<ActionResult<object>> UpdateAppointment(Guid id, Appointment Appointment)
        {
            try
            {
                Appointment appointment = await _context.Appointment.FirstOrDefaultAsync(u => u.AppointmentID == id);


                Appointment.TenantID = Appointment.TenantID;
                Appointment.PatientID = Appointment.PatientID;
                Appointment.ID = Appointment.ID;
                Appointment.Type = Appointment.Type;
                Appointment.AppointmentDate = Appointment.AppointmentDate;
                Appointment.AppointmentTime = Appointment.AppointmentTime;
                Appointment.Reason = Appointment.Reason;
                Appointment.Notes = Appointment.Notes;
                Appointment.CreatedBy = Appointment.CreatedBy;
                Appointment.CreatedOn = Appointment.CreatedOn;
                Appointment.UpdatedBy = Appointment.UpdatedBy;
                Appointment.UpdatedOn = Appointment.UpdatedOn;
                Appointment.IsActive = Appointment.IsActive;



                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
