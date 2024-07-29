using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DartPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PlusDbContext _context;
        private readonly IPatientService _iPatientService;

        public PatientController(PlusDbContext context, IPatientService iPatientService)
        {
            _context = context;
            _iPatientService = iPatientService;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            return await _iPatientService.GetPatients();
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(Guid id)
        {
            return await _iPatientService.GetPatient(id);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] Patients Patient)
        {
            return await _iPatientService.AddPatient(Patient);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put(Guid id, [FromBody] Patients Patient)
        {
            return await _iPatientService.UpdatePatient(id,Patient);

        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(Guid id)
        {
            return await _iPatientService.DeletePatient(id);

        }
    }
}
