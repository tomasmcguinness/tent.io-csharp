using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TentIo.Server.API.Controllers
{
  public class HomeController : ApiController
  {
    public HttpResponseMessage Head()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      response.Headers.Add("Tent-Server", "http://localhost");
      return response;
    }
  }
}
