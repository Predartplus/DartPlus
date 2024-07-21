using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class Tenants
    {
        [Key]
        public Guid TenantID { get; set; }
        public required string TenantName { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }        
    }
}
