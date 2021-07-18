using JunoRest.Responses;
using System.Threading.Tasks;

namespace JunoRest.Interfaces
{
    public interface IJunoBalance
    {
        Task<BalanceResponse> GetBalanceAsync();
    }
}
