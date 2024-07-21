using DartPlusAPI.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface ITenantService
    {
        Task<ActionResult<object>> GetTenants();
        Task<ActionResult<object>> GetTenant(Guid id);
        Task<ActionResult<object>> AddTenant(Tenants Tenant);
        Task<ActionResult<object>> UpdateTenant(Tenants Tenant);
        Task<ActionResult<object>> DeleteTenant(Guid id);
    }
}
