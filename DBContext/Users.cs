using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public Guid TenantID { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
