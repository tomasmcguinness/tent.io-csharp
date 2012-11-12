using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentIo.Client.ProfileInfoTypes;

namespace TentIo.Client
{
    public abstract class TentEntity
    {
        public TentEntity()
        {
            this.Profile = new List<ProfileInfo>();
        }

        public string RemoteId { get; set; }
        public string Id { get; set; }
        public List<ProfileInfo> Profile { get; private set; }
    }
}
