namespace InterviewExam.Domain.Models
{
    public class Order
    {
        public Order()
        {
           OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
