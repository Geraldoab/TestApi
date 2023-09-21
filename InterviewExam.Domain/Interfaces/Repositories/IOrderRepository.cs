using InterviewExam.Domain.Models;

namespace InterviewExam.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAsync(long customerId, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken);
        public Task<Order> CreateAsync(Order newOrder, CancellationToken cancellationToken);
    }
}
