using JunoRest.Responses;
using System.Threading.Tasks;

namespace JunoRest.Interfaces
{
    public interface IJunoAuthorization
    {
        Task<TokenResponse> GenerateTokenAsync();
    }
}
