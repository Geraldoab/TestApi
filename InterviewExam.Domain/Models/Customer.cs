namespace InterviewExam.Domain.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
        public int CustomerId {  get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
