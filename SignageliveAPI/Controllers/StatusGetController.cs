using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace SignageliveAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusGetController : ControllerBase
    {
        private IConfiguration configuration;
        public StatusGetController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet(Name = "StatusGet")]
        public async Task<RestResponse> Get(string access_token)
        {
            RestClient restClient = new RestClient(configuration["baseUrl"]);
            string method = string.Concat("networks/", configuration["networkId"], "/NetworkStatus");
            RestRequest request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", string.Concat("bearer", " ", access_token));
            return await restClient.GetAsync(request);
        }
    }
}