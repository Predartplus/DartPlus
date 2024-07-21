using Microsoft.CodeAnalysis.Scripting;

namespace DartPlusAPI.Utility
{
    public static class CommonUtility
    {
        public static string HashPassword(string Password,string Salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password,Salt);
        }
        public static string HashPassword(string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password);
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
