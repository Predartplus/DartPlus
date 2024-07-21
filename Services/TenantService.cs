using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Plugins;

namespace DartPlusAPI.Services
{
    public class TenantService: ITenantService
    {
        private readonly PlusDbContext _context;
        public TenantService(PlusDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<object>> GetTenants()
        {
            return await _context.Tenants.ToListAsync();
        }
        public async Task<ActionResult<object>> GetTenant(Guid id)
        {
            return await _context.Tenants.FirstOrDefaultAsync(u => u.TenantID == id);
        }
        public async Task<ActionResult<object>> AddTenant(Tenants Tenant)
        {
            _context.Tenants.Add(Tenant);
            return await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<object>> UpdateTenant(Tenants Tenant)
        {
            _context.Entry(Tenant).State = EntityState.Modified;

            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
        }
        public async Task<ActionResult<object>> DeleteTenant(Guid id)
        {
            try
            {
                Tenants RemoveTenant = await _context.Tenants.FindAsync(id);
                _context.Tenants.Remove(RemoveTenant);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
