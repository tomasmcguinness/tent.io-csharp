using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.Data
{
  internal class AccessTokenResponse
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("mac_key")]
    public string MacKey { get; set; }

    [JsonProperty("mac_algorithm")]
    public string MacAlgorithm { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }
  }
}
