using Newtonsoft.Json;

namespace JunoRest.Responses
{
    public class Detail
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}
