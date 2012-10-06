using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.PostTypes
{
    public class Post
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
