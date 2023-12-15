using System.Security.Cryptography;
using System.Text;

namespace SalesPortal.Common.Infrastructure;

public class PasswordEncrypter
{
    public static string EncryptPassord(string passowrd)
    {
       var md5= MD5.Create();
        byte[] inputByte = Encoding.ASCII.GetBytes(passowrd);
        byte[] hashBytes = md5.ComputeHash(inputByte);

        return Convert.ToHexString(hashBytes);
    }
}
