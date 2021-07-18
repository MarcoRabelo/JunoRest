using JunoRest.Requests;
using JunoRest.Responses;
using System.Threading.Tasks;

namespace JunoRest.Interfaces
{
    public interface IJunoCharge
    {
        Task<ChargeListResponse> GetChargesAsync();

        Task<ChargeResponse> GetChargeAsync(string chargeId);

        Task<IBillingBillResponse> GenerateBillingBillAsync(ChargeRequest body);

        Task<bool> CancelBillingBillAsync(string chargeId);
    }
}
