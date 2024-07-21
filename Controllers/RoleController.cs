using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Models.Request;
using DartPlusAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly PlusDbContext _context;
        private readonly IRoleService _iRoleService;

        public RoleController(PlusDbContext context, IRoleService iRoleService)
        {
            _context = context;
            _iRoleService = iRoleService;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            return await _iRoleService.GetRoles();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(int id)
        {
            return await _iRoleService.GetRole(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] Roles Role)
        {
            return await _iRoleService.AddRole(Role);
        }

        // PUT api/<RoleController>/5
        [HttpPut]
        public async Task<ActionResult<object>> Put([FromBody] UpdateStatusReq Role)
        {
            return await _iRoleService.UpdateRoleStatus(Role.ID,Role.UpdatedBy, Role.IsActive);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            return await _iRoleService.DeleteRole(id);
        }
    }
}
