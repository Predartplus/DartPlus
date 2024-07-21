using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Plugins;

namespace DartPlusAPI.Services
{
    public class UserService: IUserService
    {
        private readonly PlusDbContext _context;
        public UserService(PlusDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<object>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<ActionResult<object>> GetUser(Guid id)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.UserID == id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public async Task<ActionResult<object>> AddUser(Users User)
        {
            User.Password = CommonUtility.HashPassword(User.Password);
            _context.Users.Add(User);
            return await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<object>> UpdateUserStatus(Guid id, string UpdatedBy,bool IsActive)
        {
            try
            {
                Users User= await _context.Users.FirstOrDefaultAsync(u => u.UserID == id);
                User.IsActive= IsActive;
                User.UpdatedBy = UpdatedBy;
                User.UpdatedOn= DateTime.Now;
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
        }
        public async Task<ActionResult<object>> DeleteUser(Guid id)
        {
            try
            {
                Users RemoveUser = await _context.Users.FindAsync(id);
                _context.Users.Remove(RemoveUser);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
