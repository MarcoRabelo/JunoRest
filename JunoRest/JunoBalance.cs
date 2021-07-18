using JunoRest.Interfaces;
using JunoRest.Responses;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace JunoRest
{
    public sealed class JunoBalance : JunoApi, IJunoBalance
    {
        public JunoBalance(string accessToken, string privateToken, IWebProxy proxy = null) : base(accessToken, privateToken, proxy)
        {
        }

        public async Task<BalanceResponse> GetBalanceAsync()
        {
            var request = new RestRequest("balance", DataFormat.Json);

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            return await client.GetAsync<BalanceResponse>(request);
        }
    }
}
