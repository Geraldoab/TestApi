using System.Text.Json.Serialization;

namespace InterviewExam.Api.Contracts.Customers
{
    public class CustomerPutRequest
    {
        [JsonPropertyName("customer_name")]
        public string Name { get; set; }

        [JsonPropertyName("balance")]
        public double Balance { get; set; }
    }
}
