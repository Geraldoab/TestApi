using InterviewExam.Domain.Models;

namespace InterviewExam.Application.Customers
{
    public interface ICustomerService
    {
        public Task<Customer?> GetAsync(long customerId, CancellationToken cancellationToken);
        public Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
        public Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken);
    }
}
