using InterviewExam.Domain.Models;

namespace InterviewExam.Application.Orders
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetAsync(int customerId, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken);
        public Task<Order> CreateAsync(Order newOrder, CancellationToken cancellationToken);
    }
}
