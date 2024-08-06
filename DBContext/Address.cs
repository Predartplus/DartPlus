using System.ComponentModel.DataAnnotations;

namespace DartPlusAPI.DBContext
{
    public class Address : Base
    {
        public Guid AddressID { get; set; }
        public Guid ID { get; set; }
        public string Type { get; set; }
        public string AddressType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

    }
}
