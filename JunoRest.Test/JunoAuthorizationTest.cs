using System.Threading.Tasks;
using Xunit;

namespace JunoRest.Test
{
    /// <summary>
    /// Teste de autenticação no servidor de autenticação da Juno
    /// </summary>
    public class JunoAuthorizationTest : JunoApiCredentials
    {
        [Fact]
        public async Task GenerateTokenTestAsync()
        {
            var auth = new JunoAuthorization(ClientId, ClientSecret, null, SandboxAuthBaseUrl);
            var response = await auth.GenerateTokenAsync();

            Assert.NotNull(response);
            Assert.NotNull(response.AccessToken);
            Assert.NotEmpty(response.AccessToken);
        }
    }
}
