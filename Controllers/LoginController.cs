using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Models.Request;
using DartPlusAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PlusDbContext _context;
        private readonly ILoginService _iLoginService;

        public LoginController(PlusDbContext context, ILoginService iLoginService)
        {
            _context = context;
            _iLoginService = iLoginService;
        }
        [HttpPost]
        public async Task<ActionResult<object>> VerifyLogin([FromBody] LoginReq login)
        {
            return await _iLoginService.VerifyLogin(login);
        }

    }
}
