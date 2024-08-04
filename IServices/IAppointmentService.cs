using DartPlusAPI.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface IAppointmentService
    {
        Task<ActionResult<object>> GetAppointmentList();
        Task<ActionResult<object>> GetAppointment(Guid id);
        Task<ActionResult<object>> AddAppointment(Appointment Appointment);
        Task<ActionResult<object>> UpdateAppointment(Guid id, Appointment Appointment);
        Task<ActionResult<object>> DeleteAppointment(Guid id);
    }
}
