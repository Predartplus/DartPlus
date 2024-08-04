using DartPlusAPI.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace DartPlusAPI.IServices
{
    public interface IAddressService
    {
        Task<ActionResult<object>> GetAddressList();
        Task<ActionResult<object>> GetAddress(Guid id);
        Task<ActionResult<object>> AddAddress(Address Address);
        Task<ActionResult<object>> UpdateAddress(Guid id, Address Address);
        Task<ActionResult<object>> DeleteAddress(Guid id);
    }
}
