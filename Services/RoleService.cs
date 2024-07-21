using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Plugins;

namespace DartPlusAPI.Services
{
    public class RoleService: IRoleService
    {
        private readonly PlusDbContext _context;
        public RoleService(PlusDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<object>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<ActionResult<object>> GetRole(int id)
        {
            try
            {
                return await _context.Roles.FirstOrDefaultAsync(u => u.RoleID == id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public async Task<ActionResult<object>> AddRole(Roles Role)
        {
            _context.Roles.Add(Role);
            return await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<object>> UpdateRoleStatus(int id,string UpdatedBy, bool IsActive)
        {
            try
            {
                Roles Role= await _context.Roles.FirstOrDefaultAsync(u => u.RoleID == id);
                Role.IsActive = IsActive;
                Role.UpdatedBy = UpdatedBy;
                Role.UpdatedOn = DateTime.Now;
                Role.IsActive= IsActive;
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
        }
        public async Task<ActionResult<object>> DeleteRole(int id)
        {
            try
            {
                Roles RemoveRole = await _context.Roles.FindAsync(id);
                _context.Roles.Remove(RemoveRole);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
