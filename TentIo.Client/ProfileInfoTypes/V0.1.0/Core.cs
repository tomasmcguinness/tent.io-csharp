using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.ProfileInfoTypes.V0._1._0
{
    public class Core : ProfileInfo
    {
        public string Entity { get; set; }
        public List<String> Servers { get; set; }
    }
}
