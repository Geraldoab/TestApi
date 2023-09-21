using InterviewExam.Domain.Models;

namespace InterviewExam.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public Task<Customer?> GetAsync(long customerId, CancellationToken cancellationToken);
        public Task<double> GetBalanceAsync(long customerId, CancellationToken cancellationToken);
        public Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken);
        public Task UpdateBalanceAsync(long customerId, double newBalance, CancellationToken cancellationToken);
        public Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
    }
}
