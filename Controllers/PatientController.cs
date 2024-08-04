using DartPlusAPI.DBContext;
using DartPlusAPI.IServices;
using DartPlusAPI.Models.Request;
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
        private readonly IAddressService _IAddressService;
        private readonly IEmergencyContactService _IEmergencyContactService;
        public PatientController(PlusDbContext context, IPatientService iPatientService, IAddressService iAddressService, IEmergencyContactService iEmergencyContactService)
        {
            _context = context;
            _iPatientService = iPatientService;
            _IAddressService = iAddressService;
            _IEmergencyContactService = iEmergencyContactService;
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
        public async Task<ActionResult<object>> Post([FromBody] PatientReq Patient)
        {
            Patients objPatients = new Patients()
            {
                PatientID = Guid.NewGuid(),
                PatientName = Patient.PatientName
            };


            objPatients.PatientDateOfBirth = Patient.PatientDateOfBirth;
            objPatients.PatientGender = Patient.PatientGender;
            objPatients.PatientPhoneNumber = Patient.PatientPhoneNumber;
            objPatients.PatientEmail = Patient.PatientEmail;
            objPatients.PatientMaritalStatus = Patient.PatientMaritalStatus;
            objPatients.BloodGroupID = Patient.BloodGroupID;
            objPatients.InsuranceProvider = Patient.InsuranceProvider;
            objPatients.InsurancePolicyNumber = Patient.InsurancePolicyNumber;
            objPatients.CreatedBy = Patient.CreatedBy;
            objPatients.UpdatedBy = Patient.UpdatedBy;

            await _iPatientService.AddPatient(objPatients);

            if (Patient.Address.Count > 0)
            {
                foreach (Address objAddress in Patient.Address)
                {
                    objAddress.AddressID = Guid.NewGuid();
                    objAddress.ID = objPatients.PatientID;
                    await _IAddressService.AddAddress(objAddress);
                }
            }

            if (Patient.EmergencyContact.Count > 0)
            {
                foreach (EmergencyContact objEmergencyContact in Patient.EmergencyContact)
                {
                    objEmergencyContact.EmergencyContactID = Guid.NewGuid();
                    objEmergencyContact.PatientsID = objPatients.PatientID;

                    await _IEmergencyContactService.AddEmergencyContact(objEmergencyContact);
                }
            }

            return Ok("success");

        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put(Guid id, [FromBody] Patients Patient)
        {
            return await _iPatientService.UpdatePatient(id, Patient);

        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(Guid id)
        {
            return await _iPatientService.DeletePatient(id);

        }
    }
}
