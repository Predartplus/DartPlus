using DartPlusAPI.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface IUserService
    {
        Task<ActionResult<object>> GetUsers();
        Task<ActionResult<object>> GetUser(Guid id);
        Task<ActionResult<object>> AddUser(Users User);
        Task<ActionResult<object>> UpdateUserStatus(Guid idUpdatedBy,string UpdatedBy,bool IsActive);
        Task<ActionResult<object>> DeleteUser(Guid id);
    }
}
