using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.Data
{
  public class AppAuthenticationDetails
  {
    public string AccessToken { get; set; }

    public string TokenType { get; set; }

    public string MacAlgorithm { get; set; }

    public string MacKey { get; set; }
  }
}
