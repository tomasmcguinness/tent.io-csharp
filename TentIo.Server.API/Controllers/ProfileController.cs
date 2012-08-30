using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using TentIo.Common;

namespace TentIo.Server.API.Controllers
{
  public class ProfileController : ApiController
  {
    public HttpResponseMessage Get()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      response.Content = new ObjectContent(typeof(Profile), new Profile(), new JsonMediaTypeFormatter());
      return response;
    }
  }
}
