using Newtonsoft.Json;

namespace JunoRest.Responses
{
    public class BalanceResponse
    {
        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("withheldBalance")]
        public double WithheldBalance { get; set; }

        [JsonProperty("transferableBalance")]
        public double TransferableBalance { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
