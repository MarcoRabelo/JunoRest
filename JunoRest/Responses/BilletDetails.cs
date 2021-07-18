using Newtonsoft.Json;

namespace JunoRest.Responses
{
    public class BilletDetails
    {
        [JsonProperty("bankAccount")]
        public string BankAccount { get; set; }

        [JsonProperty("ourNumber")]
        public string OurNumber { get; set; }

        [JsonProperty("barcodeNumber")]
        public string BarcodeNumber { get; set; }

        [JsonProperty("portfolio")]
        public string Portfolio { get; set; }
    }
}
