namespace DartPlusAPI.Models.Request
{
    public class UpdateStatusReq
    {
        public Guid GuidID { get; set; }
        public int ID { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
