using DartPlusAPI.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface IPatientService
    {
        Task<ActionResult<object>> GetPatients();
        Task<ActionResult<object>> GetPatient(Guid id);
        Task<ActionResult<object>> AddPatient(Patients Patient);
        Task<ActionResult<object>> UpdatePatient(Guid id, Patients Patient);
        Task<ActionResult<object>> DeletePatient(Guid id);
    }
}
