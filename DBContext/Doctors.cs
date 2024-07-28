using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class Doctors: Base
    {
        [Key]
        public Guid DoctorID { get; set; }
        public string DoctorName { get; set; }
        public Guid QualificationID { get; set; }
        public string MemberShip { get; set; }
        public string Registration { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorMobile { get; set; }
    }
}
