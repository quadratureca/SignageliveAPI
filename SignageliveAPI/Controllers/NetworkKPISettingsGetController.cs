using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Sockets;

namespace SignageliveAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkKPISettingsGetController : ControllerBase
    {
        private IConfiguration configuration;
        public NetworkKPISettingsGetController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet(Name = "NetworkKPISettingsGet")]
        public async Task<RestResponse> Get(string access_token)
        {
            RestClient restClient = new RestClient(configuration["baseUrl"]);
            string networkId = configuration["networkId"];
            string method = $"networks/{networkId}/NetworkKPISettings";
            RestRequest request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", string.Concat("bearer", " ", access_token));
            return await restClient.GetAsync(request);
        }
    }
}