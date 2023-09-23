namespace InterviewExam.Api.Contracts.Orders
{
    public class LineItemResponse
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long QuantityPurchased { get; set; }
        public double TotalCost { get; set; }
    }
}
