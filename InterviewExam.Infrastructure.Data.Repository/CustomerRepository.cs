using Castle.Core.Resource;
using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using InterviewExam.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InterviewExam.Infrastructure.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InterviewExamContext _context;
        public CustomerRepository(InterviewExamContext context)
        {
            this._context = context;        
        }

        public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return customer;
        }

        public async Task<Customer?> GetAsync(long customerId, CancellationToken cancellationToken)
        {
            return await _context.Customers.FirstOrDefaultAsync(w=> w.CustomerId == customerId, cancellationToken);
        }

        public Task<double> GetBalanceAsync(long customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
        {
            var oldCustomer = await _context.Customers.FirstOrDefaultAsync(w => w.CustomerId == customer.CustomerId, cancellationToken);

            oldCustomer!.Name = customer.Name;
            oldCustomer.Balance = customer.Balance;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateBalanceAsync(long customerId, double newBalance, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}