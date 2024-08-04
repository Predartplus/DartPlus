using DartPlusAPI.DBContext;

namespace DartPlusAPI.Models.Request
{
    public class PatientReq : Base
    {
        public required Guid PatientID { get; set; }

        public List<EmergencyContact> EmergencyContact { get; set; } = new List<EmergencyContact>();

        public List<Address> Address { get; set; } = new List<Address>();


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
