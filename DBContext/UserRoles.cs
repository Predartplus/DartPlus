using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class UserRoles
    {
        [Key]
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }       
    }
}
