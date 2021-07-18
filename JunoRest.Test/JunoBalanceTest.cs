using System.Threading.Tasks;
using Xunit;

namespace JunoRest.Test
{
    /// <summary>
    /// Testes para obter os saldos de uma conta da Juno
    /// </summary>
    public class JunoBalanceTest : JunoApiCredentials
    {
        [Fact]
        public async Task GetBalanceTestAsync()
        {
            var auth = new JunoAuthorization(ClientId, ClientSecret, null, SandboxAuthBaseUrl);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var balance = new JunoBalance(tokenResponse.AccessToken, PrivateToken, null);
            var balanceResponse = await balance.GetBalanceAsync();

            Assert.NotNull(balanceResponse);
        }
    }
}
