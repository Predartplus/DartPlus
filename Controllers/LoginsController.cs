using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DartPlusAPI.Models;
using DartPlusAPI.Models.Request;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DartPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly PlusDbContext _context;

        public LoginsController(PlusDbContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogin()
        {
            var test= await _context.Login.ToListAsync();
            return test;
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Logins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.UserID)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Logins
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.UserID }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("Verify")]
        public async Task<IActionResult> LoginVerify(LoginRequest request)
        {
            var user = await _context.Login
                .Where(u => u.Username == request.Username)
                .FirstOrDefaultAsync();

            if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok("Login successful");
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.UserID == id);
        }
        private bool VerifyPassword(string password, string storedHash)
        {
            //var passwordHash = HashPassword(password);
            //return passwordHash == storedHash;
            return password == storedHash;
        }
        //private string HashPassword(string password)
        //{
        //    using (var sha256 = SHA256.Create())
        //    {
        //        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        //    }
        //}
    }
}
