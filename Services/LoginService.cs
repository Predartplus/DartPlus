using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Models.Request;
using DartPlusAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Plugins;

namespace DartPlusAPI.Services
{
    public class LoginService: ILoginService
    {
        private readonly PlusDbContext _context;
        public LoginService(PlusDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<object>> VerifyLogin(LoginReq login)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == login.UserName);
                if (user != null && CommonUtility.VerifyPassword(login.Password, user.Password))
                {
                   return "Login successful!";
                }
                else
                {
                    return "Invalid username or password.";
                }
            }
            catch (Exception ex) {
                return "Exception";
            }
        }
       
    }
}
