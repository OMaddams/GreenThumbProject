using System.IO;
using System.Security.Cryptography;

namespace GreenThumbProject.Managers
{
    public class KeyManager
    {
        public static string GetEncryptionKey()
        {
            if (File.Exists("G:\\testKEy\\key.txt"))
            {
                return File.ReadAllText("G:\\testKEy\\key.txt");
            }
            else
            {
                string key = GenerateEncryptionKey();
                File.WriteAllText("G:\\testKEy\\key.txt", key);

                return key;
            }
        }

        private static string GenerateEncryptionKey()
        {
            var rng = new RNGCryptoServiceProvider();

            var byteArray = new byte[16];

            rng.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);
        }
    }
}
