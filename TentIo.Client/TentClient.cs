using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TentIo.Client.Data;
using TentIo.Client.Formatters;

namespace TentIo.Client
{
  public class TentClient
  {
    private string serverName;

    private TentClient(string serverName)
    {
      this.serverName = serverName;
    }

    private string ServerUri(string path)
    {
      return string.Format("http://{0}/{1}", serverName, path);
    }

    /// <summary>
    /// Returns an instance of a TentClient connected to the target server.
    /// </summary>
    /// <param name="serverName"></param>
    public async static Task<TentClient> Discover(string serverName)
    {
      string uri = string.Format("http://{0}", serverName);
      HttpClient client = new HttpClient();
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, new Uri(uri));
      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.tent.v0+json"));
      HttpResponseMessage response = await client.SendAsync(request);

      // Get the profile.
      //
      var linkHeaders = response.Headers.Where(h => h.Key == "Link");

      if (linkHeaders.Count() == 0)
      {
        return null;
      }

      var profile = await GetProfile(string.Format(@"http://{0}/tent/profile", serverName));

      response.EnsureSuccessStatusCode();

      return new TentClient(serverName);
    }

    private static async Task<TentProfile> GetProfile(string profilePath)
    {
      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.tent.v0+json"));
      var response = await client.GetAsync(profilePath);

      response.EnsureSuccessStatusCode();

      TentProfile profile = await response.Content.ReadAsAsync<TentProfile>(new List<MediaTypeFormatter>() { new TentJsonMediaTypeFormatter() });

      return profile;
    }

    public async void Register(RegistrationRequest request)
    {
      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.tent.v0+json"));

      HttpContent body = new ObjectContent(request.GetType(), request, new JsonMediaTypeFormatter(), "application/vnd.tent.v0+json");

      HttpResponseMessage response = await client.PostAsync(ServerUri("apps"), body);
      response.EnsureSuccessStatusCode();

      var registrationResult = await response.Content.ReadAsAsync<RegistrationResponse>(new List<MediaTypeFormatter>() { new TentJsonMediaTypeFormatter() });


    }

    public void Follow(string serverName)
    {

    }

    public void Unfollow(string serverName)
    {

    }

    public void PostUpdate(string statusUpdate)
    {

    }

  }
}
