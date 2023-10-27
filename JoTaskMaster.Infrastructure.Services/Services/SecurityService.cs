using JoTaskMaster.Application.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;


namespace JoTaskMaster.Infrastructure.Services.Services
{
    public class SecurityService : ISecurityService
    {
        public string Hashing(string password)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(password)));
        }

        public bool PassworEqualityCheck(string currentPassword, string autorisePassword)
        {
            using SHA256 hash = SHA256.Create();
            currentPassword = Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(currentPassword)));
            autorisePassword = Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(autorisePassword)));
                
            if (currentPassword == autorisePassword)
            {
                return true;
            }
            return false;
        }
    }
}
