using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.Data
{
    public class RegistrationRequest
    {
        public RegistrationRequest()
        {
            RedirectUris = new List<string>();
            PermissionScopes = new Dictionary<string, string>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("redirect_uris")]
        public List<string> RedirectUris { get; private set; }

        [JsonProperty("scopes")]
        public Dictionary<string, string> PermissionScopes { get; private set; }

        public void AddRedirectUri(string redirectUri)
        {
            this.RedirectUris.Add(redirectUri);
        }

        public void AddPermissionScope(string scopeName, string reasonForRequesting)
        {
            this.PermissionScopes.Add(scopeName, reasonForRequesting);
        }
    }
}
