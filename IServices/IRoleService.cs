using DartPlusAPI.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface IRoleService
    {
        Task<ActionResult<object>> GetRoles();
        Task<ActionResult<object>> GetRole(int id);
        Task<ActionResult<object>> AddRole(Roles Role);
        Task<ActionResult<object>> UpdateRoleStatus(int id,string Updated,bool IsActive);
        Task<ActionResult<object>> DeleteRole(int id);
    }
}
