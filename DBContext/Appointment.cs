using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class Appointment : Base
    {
        [Key]
        public required Guid AppointmentID { get; set; }
        public required Guid TenantID { get; set; }
        public required Guid PatientID { get; set; }
        public required Guid ID { get; set; }
        public string Type { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
