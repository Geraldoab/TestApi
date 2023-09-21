using System.Text.Json.Serialization;

namespace InterviewExam.Api.Contracts.Customers
{
    public class CustomerGetResponse
    {
        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("balance")]
        public double Balance { get; set; }
    }
}
