using JunoRest.Interfaces;
using JunoRest.Requests;
using JunoRest.Responses;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace JunoRest
{
    public sealed class JunoCharge : JunoApi, IJunoCharge
    {
        public JunoCharge(string accessToken, string privateToken, IWebProxy proxy = null) : base(accessToken, privateToken, proxy)
        {
        }

        public async Task<bool> CancelBillingBillAsync(string chargeId)
        {
            var request = new RestRequest($"charges/{chargeId}/cancelation", Method.PUT);

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            var response = await client.ExecuteAsync(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<IBillingBillResponse> GenerateBillingBillAsync(ChargeRequest body)
        {
            var request = new RestRequest("charges", DataFormat.Json).AddJsonBody(JsonConvert.SerializeObject(body));

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            var response = await client.PostAsync<BillingBillResponse>(request);

            if (response.Embedded != null)
            {
                return new BillingBillResponseSuccess
                {
                    Embedded = response.Embedded
                };
            }

            return new BillingBillResponseError
            {
                Details = response.Details,
                Error = response.Error,
                Path = response.Path,
                Status = response.Status,
                Timestamp = response.Timestamp
            };
        }

        public async Task<ChargeResponse> GetChargeAsync(string chargeId)
        {
            var request = new RestRequest($"charges/{chargeId}", DataFormat.Json);

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            return await client.GetAsync<ChargeResponse>(request);
        }

        public async Task<ChargeListResponse> GetChargesAsync()
        {
            var request = new RestRequest("charges", DataFormat.Json);

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            return await client.GetAsync<ChargeListResponse>(request);
        }
    }
}
