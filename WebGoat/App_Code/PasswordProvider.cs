using System.Text;
using System.Security.Cryptography;
using System.Linq;
using Konscious.Security.Cryptography;

namespace OWASP.WebGoat.NET.App_Code
{
    public class PasswordProvider
    {
        public static byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        public static byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 2; // two cores
            argon2.Iterations = 1;
            argon2.MemorySize = 512 * 1024; // 512 MB

            return argon2.GetBytes(16);
        }

        public static bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }
    }
}
