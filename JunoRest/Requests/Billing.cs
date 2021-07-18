using Newtonsoft.Json;

namespace JunoRest.Requests
{
    public class Billing
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Data de nascimento no formato "yyyy-MM-dd"
        /// </summary>
        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("notify")]
        public bool Notify { get; set; }
    }
}
