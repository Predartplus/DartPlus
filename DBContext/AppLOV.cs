using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class AppLOV
    {
        [Key]
        public Guid AppLOVID { get; set; }
        public required string Type { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }= DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
