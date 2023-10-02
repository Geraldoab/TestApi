using System.Text.Json.Serialization;

namespace InterviewExam.Api.Contracts.Orders
{
    public class OrderProductResponse
    {
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
