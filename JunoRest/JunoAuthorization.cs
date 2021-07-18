using JunoRest.Extensions;
using JunoRest.Interfaces;
using JunoRest.Responses;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace JunoRest
{
    public sealed class JunoAuthorization : JunoApi, IJunoAuthorization
    {
        private string _basicCredentials;

        public JunoAuthorization(string clientId, string clientSecret, IWebProxy proxy = null, string baseUrl = null) : base(proxy, baseUrl)
        {
            _basicCredentials = $"{clientId}:{clientSecret}".Base64Encode();
        }

        public async Task<TokenResponse> GenerateTokenAsync()
        {
            var request = new RestRequest("authorization-server/oauth/token?grant_type=client_credentials", DataFormat.Json);
            request.AddHeader("Authorization", $"Basic {_basicCredentials}");

            return await client.PostAsync<TokenResponse>(request);
        }
    }
}
