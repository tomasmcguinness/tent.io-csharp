﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.Data
{
  public class RegistrationResponse
  {
    [JsonProperty("id")]
    public string Id { get; set; }
  }
}
