using DartPlusAPI.DBContext;
using DartPlusAPI.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface ILoginService
    {
        Task<ActionResult<object>> VerifyLogin(LoginReq login);
       
    }
}
