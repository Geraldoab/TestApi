namespace InterviewExam.Domain.Models
{
    public class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();           
        }
        public int ProductId { get; set; }
        public string Name {  get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
