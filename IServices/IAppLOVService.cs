using DartPlusAPI.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface IAppLOVService
    {
        Task<ActionResult<object>> GetAppLOVs();
        Task<ActionResult<object>> GetAppLOV(Guid id);
        Task<ActionResult<object>> GetAppLOV(string? type);
        Task<ActionResult<object>> AddAppLOV(AppLOV AppLOV);
        Task<ActionResult<object>> UpdateAppLOVStatus(Guid id,string Updated,bool IsActive);
        Task<ActionResult<object>> DeleteAppLOV(Guid id);
    }
}
