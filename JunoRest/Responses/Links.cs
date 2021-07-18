using Newtonsoft.Json;

namespace JunoRest.Responses
{
    public class Links
    {
        [JsonProperty("self")]
        public Self Self { get; set; }
    }
}
