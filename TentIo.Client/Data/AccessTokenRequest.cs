using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.Data
{
  internal class AccessTokenRequest
  {
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }
  }
}
