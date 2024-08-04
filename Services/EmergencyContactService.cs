using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DartPlusAPI.Services
{
    public class EmergencyContactService : IEmergencyContactService
    {
        private readonly PlusDbContext _context;

        public EmergencyContactService(PlusDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<object>> AddEmergencyContact(EmergencyContact EmergencyContact)
        {
            _context.EmergencyContact.Add(EmergencyContact);
            return await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<object>> DeleteEmergencyContact(Guid id)
        {
            try
            {
                EmergencyContact RemoveEmergencyContact = await _context.EmergencyContact.FindAsync(id);
                _context.EmergencyContact.Remove(RemoveEmergencyContact);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<ActionResult<object>> GetEmergencyContact(Guid id)
        {
            try
            {
                return await _context.EmergencyContact.FirstOrDefaultAsync(u => u.EmergencyContactID == id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<ActionResult<object>> GetEmergencyContactList()
        {
            return await _context.EmergencyContact.ToListAsync();
        }

        public async Task<ActionResult<object>> UpdateEmergencyContact(Guid id, EmergencyContact EmergencyContact)
        {
            try
            {
                EmergencyContact emergencyContact = await _context.EmergencyContact.FirstOrDefaultAsync(u => u.EmergencyContactID == id);


                emergencyContact.PatientsID = EmergencyContact.PatientsID;
                emergencyContact.EmergencyContactName = EmergencyContact.EmergencyContactName;
                emergencyContact.EmergencyContactPhoneNumber = EmergencyContact.EmergencyContactPhoneNumber;
                emergencyContact.EmergencyContactRelationShip = EmergencyContact.EmergencyContactRelationShip;
                emergencyContact.EmergencyContactLocation = EmergencyContact.EmergencyContactLocation;


                EmergencyContact.UpdatedBy = EmergencyContact.UpdatedBy;
                EmergencyContact.UpdatedOn = EmergencyContact.UpdatedOn;

                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
