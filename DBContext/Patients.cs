using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class Patients : Base
    {
        [Key]
        public required Guid PatientID { get; set; }
        public required string PatientName { get; set; }
        public DateTime PatientDateOfBirth { get; set; } = DateTime.Now;
        public string PatientGender { get; set; }
        public string PatientPhoneNumber { get; set; }
        public string PatientEmail { get; set; }
        public string PatientMaritalStatus { get; set; }
        public string BloodGroupID { get; set; }
        public string InsuranceProvider { get; set; }
        public string InsurancePolicyNumber { get; set; }

    }
}
