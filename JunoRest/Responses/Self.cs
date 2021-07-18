using Newtonsoft.Json;

namespace JunoRest.Responses
{
    public class Self
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
