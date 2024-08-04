using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class EmergencyContact : Base
    {
        [Key]
        public required Guid EmergencyContactID { get; set; }
        public required Guid PatientsID { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string EmergencyContactRelationShip { get; set; }
        public string EmergencyContactLocation { get; set; }
    }
}
