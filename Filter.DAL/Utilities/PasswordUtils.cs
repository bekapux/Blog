using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace Blog.DAL.Utilities
{
  public static class PasswordUtils
  {
    public static string HashPass(string password)
    {
      var bytes = new UTF8Encoding().GetBytes(password);
      byte[] hashBytes;
      using (var algorithm = new System.Security.Cryptography.HMACSHA512())
      {
        hashBytes = algorithm.ComputeHash(bytes);
      }
      var Result = Convert.ToBase64String(hashBytes);
      return Result;
    }

    public static string ToHash(this string source, string secretKey)
    {
      var sourcebytes = Encoding.Default.GetBytes($"{source}{secretKey}");
      var hasher = SHA256.Create();
      var hashBytes = hasher.ComputeHash(sourcebytes);
      var result = Regex.Replace(BitConverter.ToString(hashBytes), "-", "").ToLower(); ;

      return result;
    }
  }
}
