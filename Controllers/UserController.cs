using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Models.Request;
using DartPlusAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DartPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PlusDbContext _context;
        private readonly IUserService _iUserService;

        public UserController(PlusDbContext context, IUserService iUserService)
        {
            _context = context;
            _iUserService = iUserService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            return await _iUserService.GetUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(Guid id)
        {
            return await _iUserService.GetUser(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] Users User)
        {
            return await _iUserService.AddUser(User);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<ActionResult<object>> Put([FromBody] UpdateStatusReq User)
        {
            return await _iUserService.UpdateUserStatus(User.GuidID, User.UpdatedBy, User.IsActive);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(Guid id)
        {
            return await _iUserService.DeleteUser(id);
        }
    }
}
