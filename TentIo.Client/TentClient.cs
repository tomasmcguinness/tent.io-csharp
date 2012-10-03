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
    private string apiPath;

    private TentClient(string serverName, string apiPath)
    {
      this.serverName = serverName;
      this.apiPath = apiPath;
    }

    private string ServerUri(string path)
    {
      return string.Format("https://{0}/{1}/{2}", serverName, apiPath, path);
    }

    /// <summary>
    /// Returns an instance of a TentClient connected to the target server.
    /// </summary>
    /// <param name="serverName"></param>
    public async static Task<TentClient> Discover(string serverName)
    {
      string uri = string.Format("http://{0}/tent", serverName);
      HttpClient client = new HttpClient();
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, new Uri(uri));
      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.tent.v0+json"));
      HttpResponseMessage response = await client.SendAsync(request);

      // Get the profile.
      //
      var linkHeaders = response.Headers.Where(h => h.Key == "Link").ToList();

      if (linkHeaders.Count() == 0)
      {
        return null;
      }

      //Link: </profile>; rel="https://tent.io/rels/profile"

      string apiPath = null;

      foreach (var linkHeader in linkHeaders)
      {
        foreach (var headerValue in linkHeader.Value)
        {
          if (headerValue.Contains(@"rel=""https://tent.io/rels/profile"""))
          {
            apiPath = headerValue.Split(';')[0].Replace("<", "").Replace(">", "");
            apiPath = apiPath.Replace("/profile", "").Replace("/", "");
          }
        }
      }


      var profile = await GetProfile(string.Format(@"https://{0}/{1}/profile", serverName, apiPath));

      response.EnsureSuccessStatusCode();

      return new TentClient(serverName, apiPath);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<String> Register(RegistrationRequest request)
    {
      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.tent.v0+json"));

      HttpContent body = new ObjectContent(request.GetType(), request, new JsonMediaTypeFormatter(), "application/vnd.tent.v0+json");

      HttpResponseMessage response = await client.PostAsync(ServerUri("apps"), body);
      response.EnsureSuccessStatusCode();

      var registrationResult = await response.Content.ReadAsAsync<RegistrationResponse>(new List<MediaTypeFormatter>() { new TentJsonMediaTypeFormatter() });

      var oauthUrl = new StringBuilder();
      oauthUrl.Append(ServerUri("/oauth/authorize"));
      oauthUrl.AppendFormat("?client_id={0}", registrationResult.Id);
      oauthUrl.AppendFormat("&redirect_uri={0}", request.RedirectUris[0]);



      //oauthUrl.AppendFormat("&scope={0}", "write_posts,write_posts,read_followers");
      //oauthUrl.AppendFormat("&state={0}", new Random().Next());
      //oauthUrl.AppendFormat("&tent_profile_info_types={0}", "https://tent.io/types/info/music/v0.1.0");
      //oauthUrl.AppendFormat("&tent_post_types={0}", "https://tent.io/types/posts/status/v0.1.0");

      return oauthUrl.ToString();
    }

    public async Task<AppAuthenticationDetails> ProcessRegisterCallback(Uri url)
    {
      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.tent.v0+json"));

      AccessTokenRequest request = new AccessTokenRequest();
      request.Code = "c54bf24a29b929e1875a3a7c3ce8f031";
      request.TokenType = "mac"; // Only supported type at present.

      HttpContent body = new ObjectContent(request.GetType(), request, new JsonMediaTypeFormatter(), "application/vnd.tent.v0+json");

      HttpResponseMessage response = await client.PostAsync(ServerUri("apps"), body);
      response.EnsureSuccessStatusCode();

      var accessTokenResponse = await response.Content.ReadAsAsync<AccessTokenResponse>(new List<MediaTypeFormatter>() { new TentJsonMediaTypeFormatter() });

      return new AppAuthenticationDetails()
      {
        AccessToken = accessTokenResponse.AccessToken,
        MacKey = accessTokenResponse.MacKey,
        MacAlgorithm = accessTokenResponse.MacAlgorithm,
        TokenType = accessTokenResponse.TokenType
      };
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
