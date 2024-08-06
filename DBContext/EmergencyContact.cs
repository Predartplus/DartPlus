using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class EmergencyContact : Base
    {
        public Guid EmergencyContactID { get; set; }
        public Guid PatientsID { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string EmergencyContactRelationShip { get; set; }
        public string EmergencyContactLocation { get; set; }
    }
}
