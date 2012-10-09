using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.Types
{
    public abstract class TentEntity
    {
        [JsonProperty("remote_id")]
        public string RemoteId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
