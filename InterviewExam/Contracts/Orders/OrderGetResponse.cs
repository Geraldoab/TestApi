using System.Text.Json.Serialization;

namespace InterviewExam.Api.Contracts.Orders
{
    public class OrderGetResponse
    {
        [JsonPropertyName("order_id")]
        public long OrderId { get; set; }

        [JsonPropertyName("customer_id")]
        public long CustomerId { get; set; }

        [JsonPropertyName("order_date")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("total")]
        public double Total { get; set; }

        [JsonPropertyName("line_items")]
        public List<LineItemResponse> LineItems { get; set; }
    }
}
