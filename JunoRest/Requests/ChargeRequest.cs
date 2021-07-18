using Newtonsoft.Json;

namespace JunoRest.Requests
{
    public class ChargeRequest
    {
        [JsonProperty("charge")]
        public Charge Charge { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }
    }
}
