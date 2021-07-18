using System;
using System.Net;

namespace JunoRest.Test
{
    public abstract class JunoApiCredentials
    {
        //URL de autenticação do ambiente sandbox.
        public static string SandboxAuthBaseUrl = "https://sandbox.boletobancario.com";

        //Menu > Integração > Criação de Credencial
        public static string ClientId = "ClientId";
        public static string ClientSecret = "ClientSecret";

        //Token de recurso: menu > integração > token privado
        public static string PrivateToken = "PrivateToken";

        //Idempotency-Key
        public static Guid IdempotencyKey = new Guid("f677f53b-34a1-4a5d-8c06-e1907851eddc");

        //Proxy, caso necessário
        public static IWebProxy Proxy = new WebProxy
        {
            Address = new Uri($"http://proxyurl.com.br"),
            BypassProxyOnLocal = false,
            UseDefaultCredentials = false,

            Credentials = new NetworkCredential(userName: @"user", password: "password")
        };
    }
}
