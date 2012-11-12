using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.ProfileInfoTypes.V0._1._0
{
    public class Basic : ProfileInfo
    {
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string BirthDate { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
    }
}
