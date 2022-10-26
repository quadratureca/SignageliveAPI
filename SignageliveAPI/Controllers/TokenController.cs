using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace SignageliveAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private IConfiguration configuration;
        public TokenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost(Name = "PostToken")]
        public async Task<RestResponse> Post()
        {
            RestClient restClient = new RestClient(configuration["baseUrl"]);
            RestRequest request = new RestRequest("token");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "authorization_code");
            // Add your own client id, client secret and authorization code here 
            request.AddParameter("client_id", configuration["clientId"]);
            request.AddParameter("client_secret", configuration["clientSecret"]);
            request.AddParameter("code", configuration["authorizationCode"]); 
            return await restClient.PostAsync(request);
        }
    }
}