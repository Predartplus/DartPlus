using DartPlusAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DartPlusAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly PlusDbContext _context;

        public TestController(PlusDbContext context)
        {
            _context = context;
        }
        [HttpGet("Test")]
        public List<Login> GetTest()
        {
             var test = _context.Login.ToList();
            return test;
            //WeatherForecast t
            //    = new WeatherForecast();
            //return  t;
        }

    }
}
