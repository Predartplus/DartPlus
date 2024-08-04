using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DartPlusAPI.Services
{
    public class AddressService : IAddressService
    {
        private readonly PlusDbContext _context;

        public AddressService(PlusDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<object>> AddAddress(Address Address)
        {
            _context.Address.Add(Address);
            return await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<object>> DeleteAddress(Guid id)
        {
            try
            {
                Address RemoveAddress = await _context.Address.FindAsync(id);
                _context.Address.Remove(RemoveAddress);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<ActionResult<object>> GetAddress(Guid id)
        {
            try
            {
                return await _context.Address.FirstOrDefaultAsync(u => u.AddressID == id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<ActionResult<object>> GetAddressList()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task<ActionResult<object>> UpdateAddress(Guid id, Address Address)
        {
            try
            {
                Address address = await _context.Address.FirstOrDefaultAsync(u => u.AddressID == id);

                address.ID = Address.ID;
                address.Type = Address.Type;
                address.AddressType = Address.AddressType;
                address.Address1 = Address.Address1;
                address.Address2 = Address.Address2;
                address.City = Address.City;
                address.State = Address.State;
                address.Country = Address.Country;
                address.ZipCode = Address.ZipCode;

                address.UpdatedBy = Address.UpdatedBy;
                address.UpdatedOn = Address.UpdatedOn;

                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
