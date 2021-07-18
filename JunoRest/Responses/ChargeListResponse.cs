using Newtonsoft.Json;

namespace JunoRest.Responses
{
    public class ChargeListResponse
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
