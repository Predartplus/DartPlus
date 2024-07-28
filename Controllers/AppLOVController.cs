using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Models.Request;
using DartPlusAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppLOVController : ControllerBase
    {
        private readonly PlusDbContext _context;
        private readonly IAppLOVService _iAppLOVService;

        public AppLOVController(PlusDbContext context, IAppLOVService iAppLOVService)
        {
            _context = context;
            _iAppLOVService = iAppLOVService;
        }
        // GET: api/<AppLOVController>
        //[HttpGet]
        //public async Task<ActionResult<object>> Get()
        //{
        //    return await _iAppLOVService.GetAppLOVs();
        //}

        // GET api/<AppLOVController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(Guid id)
        {
            return await _iAppLOVService.GetAppLOV(id);
        }

        // GET api/<AppLOVController>/5
        [HttpGet]
        
        public async Task<ActionResult<object>> GetLOV([FromQuery] string? type)
        {
            return await _iAppLOVService.GetAppLOV(type);
        }

        // POST api/<AppLOVController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] AppLOV AppLOV)
        {
            return await _iAppLOVService.AddAppLOV(AppLOV);
        }

        // PUT api/<AppLOVController>/5
        [HttpPut]
        public async Task<ActionResult<object>> Put([FromBody] UpdateStatusReq AppLOV)
        {
            return await _iAppLOVService.UpdateAppLOVStatus(AppLOV.GuidID,AppLOV.UpdatedBy, AppLOV.IsActive);
        }

        // DELETE api/<AppLOVController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(Guid id)
        {
            return await _iAppLOVService.DeleteAppLOV(id);
        }
    }
}
