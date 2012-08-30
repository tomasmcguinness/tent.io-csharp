using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Common
{
  public class Profile
  {
    public Profile()
    {
      Type = new ProfileType();
    }

    public ProfileType Type { get; private set; }
  }
}
