using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class Users
    {
        [Key]
        public Guid UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public Guid TenantID { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }= DateTime.Now;
        public bool IsActive { get; set; }=true;
    }
}
