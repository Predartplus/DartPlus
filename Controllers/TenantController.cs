using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DartPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly PlusDbContext _context;
        private readonly ITenantService _iTenantService;

        public TenantController(PlusDbContext context, ITenantService iTenantService)
        {
            _context = context;
            _iTenantService = iTenantService;
        }
        // GET: api/<TenantController>
        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            return await _iTenantService.GetTenants();
        }

        // GET api/<TenantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(Guid id)
        {
            return await _iTenantService.GetTenant(id);
        }

        // POST api/<TenantController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] Tenants Tenant)
        {
            return await _iTenantService.AddTenant(Tenant);
        }

        // PUT api/<TenantController>/5
        [HttpPut]
        public async Task<ActionResult<object>> Put([FromBody] Tenants Tenant)
        {
            return await _iTenantService.UpdateTenant(Tenant);
        }

        // DELETE api/<TenantController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(Guid id)
        {
            return await _iTenantService.DeleteTenant(id);
        }
    }
}
