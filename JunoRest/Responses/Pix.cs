using Newtonsoft.Json;

namespace JunoRest.Responses
{
    public class Pix
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("payloadInBase64")]
        public string PayloadInBase64 { get; set; }

        [JsonProperty("imageInBase64")]
        public string ImageInBase64 { get; set; }
    }
}
