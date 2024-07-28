using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Plugins;

namespace DartPlusAPI.Services
{
    public class AppLOVService: IAppLOVService
    {
        private readonly PlusDbContext _context;
        public AppLOVService(PlusDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<object>> GetAppLOVs()
        {
            return await _context.AppLOV.ToListAsync();
        }
        public async Task<ActionResult<object>> GetAppLOV(Guid id)
        {
            try
            {
                return await _context.AppLOV.FirstOrDefaultAsync(u => u.AppLOVID == id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public async Task<ActionResult<object>> GetAppLOV(string? type)
        {
            try
            {
                return await _context.AppLOV.Where(u => (u.Type == type || string.IsNullOrEmpty(type))).ToListAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public async Task<ActionResult<object>> AddAppLOV(AppLOV AppLOV)
        {
            _context.AppLOV.Add(AppLOV);
            return await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<object>> UpdateAppLOVStatus(Guid id,string UpdatedBy, bool IsActive)
        {
            try
            {
                AppLOV AppLOV= await _context.AppLOV.FirstOrDefaultAsync(u => u.AppLOVID == id);
                AppLOV.IsActive = IsActive;
                AppLOV.UpdatedBy = UpdatedBy;
                AppLOV.UpdatedOn = DateTime.Now;
                AppLOV.IsActive= IsActive;
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
        }
        public async Task<ActionResult<object>> DeleteAppLOV(Guid id)
        {
            try
            {
                AppLOV RemoveAppLOV = await _context.AppLOV.FindAsync(id);
                _context.AppLOV.Remove(RemoveAppLOV);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
