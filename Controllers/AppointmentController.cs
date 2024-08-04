using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.Controllers
{
    public class AppointmentController : ControllerBase
    {
        private readonly PlusDbContext _context;
        private readonly IAppointmentService _iAppointmentService;

        public AppointmentController(PlusDbContext context, IAppointmentService iAppointmentService)
        {
            _context = context;
            _iAppointmentService = iAppointmentService;
        }

        // GET: api/<AppointmentController>
        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            return await _iAppointmentService.GetAppointmentList();
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(Guid id)
        {
            return await _iAppointmentService.GetAppointment(id);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] Appointment Appointment)
        {
            
            await _iAppointmentService.AddAppointment(Appointment);

            return Ok("success");

        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put(Guid id, [FromBody] Appointment Appointment)
        {
            return await _iAppointmentService.UpdateAppointment(id, Appointment);

        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(Guid id)
        {
            return await _iAppointmentService.DeleteAppointment(id);

        }
    }
}
