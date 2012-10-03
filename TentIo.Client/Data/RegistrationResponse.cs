using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.Data
{
  internal class RegistrationResponse
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("mac_algorithm")]
    public string MacAlgorithm { get; set; }

    [JsonProperty("mac_key_id")]
    public string MacKeyIdentifier { get; set; }

    [JsonProperty("mac_key")]
    public string MacKey { get; set; }
  }
}
