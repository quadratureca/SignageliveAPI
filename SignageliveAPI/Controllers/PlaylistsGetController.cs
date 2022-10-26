using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Sockets;

namespace SignageliveAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistsGetController : ControllerBase
    {
        private IConfiguration configuration;
        public PlaylistsGetController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet(Name = "PlaylistsGet")]
        public async Task<RestResponse> Get(string access_token, int playlistId)
        {
            RestClient restClient = new RestClient(configuration["baseUrl"]);
            string networkId = configuration["networkId"];
            string method = $"networks/{networkId}/Playlists/{playlistId}";
            RestRequest request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", string.Concat("bearer", " ", access_token));
            return await restClient.GetAsync(request);
        }
    }
}