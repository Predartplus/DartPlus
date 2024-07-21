namespace DartPlusAPI.Models.Request
{
    public class LoginReq
    {
        public required string Password { get; set; }
        public required string UserName { get; set; }
    }
}
