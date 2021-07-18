using RestSharp;
using System.Net;

namespace JunoRest
{
    public abstract class JunoApi
    {
        protected RestClient client;
        protected string _privateToken;
        //protected string _baseUrl = "https://api.juno.com.br"; //Produção
        protected string _baseUrl = "https://sandbox.boletobancario.com/api-integration"; //Sandbox

        public JunoApi(IWebProxy proxy = null, string baseUrl = null)
        {
            client = new RestClient(string.IsNullOrEmpty(baseUrl) ? _baseUrl : baseUrl)
            {
                Proxy = proxy
            };
        }

        public JunoApi(string accessToken, string privateToken, IWebProxy proxy = null, string baseUrl = null) : this(proxy, baseUrl)
        {
            client.AddDefaultHeader("Authorization", $"Bearer {accessToken}");
            _privateToken = privateToken;
        }
    }
}
