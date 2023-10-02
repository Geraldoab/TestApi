using InterviewExam.Api.Contracts.Products;
using System.Text.Json.Serialization;

namespace InterviewExam.Api.Contracts.Orders
{
    public class OrderPostResponse
    {
        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("products")]
        public ICollection<OrderProductResponse>? Products { get; set; }
    }
}
