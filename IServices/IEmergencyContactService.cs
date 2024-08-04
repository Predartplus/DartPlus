using DartPlusAPI.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface IEmergencyContactService
    {
        Task<ActionResult<object>> GetEmergencyContactList();
        Task<ActionResult<object>> GetEmergencyContact(Guid id);
        Task<ActionResult<object>> AddEmergencyContact(EmergencyContact EmergencyContact);
        Task<ActionResult<object>> UpdateEmergencyContact(Guid id, EmergencyContact EmergencyContact);
        Task<ActionResult<object>> DeleteEmergencyContact(Guid id);
    }
}
