using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MACHelper
{
  public class Helper
  {
    public static string GetAuthorizationHeader(string macKeyIdentifier, string macKey, string macAlgorithm, string method, Uri uri)
    {
      TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
      string timestamp = ((int)t.TotalSeconds).ToString();

      string nonce = new Random().Next().ToString();

      string normalizedString = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n\n", timestamp, nonce, method, uri.PathAndQuery, uri.Host, uri.Port);

      HashAlgorithm hashGenerator = null;

      if (macAlgorithm == "hmac-sha-256")
      {
        hashGenerator = new HMACSHA256(Encoding.ASCII.GetBytes(macKey));
      }
      else if (macAlgorithm == "hmac-sha-1")
      {
        hashGenerator = new HMACSHA1(Encoding.ASCII.GetBytes(macKey));
      }
      else
      {
        throw new InvalidOperationException("Unsupported MAC algorithm");
      }

      string hash = System.Convert.ToBase64String(hashGenerator.ComputeHash(Encoding.ASCII.GetBytes(normalizedString)));

      StringBuilder authorizationHeader = new StringBuilder();
      authorizationHeader.AppendFormat(@"id=""{0}"",ts=""{1}"",nonce=""{2}"",mac=""{3}""", macKeyIdentifier, timestamp, nonce, hash);

      return authorizationHeader.ToString();
    }
  }
}
