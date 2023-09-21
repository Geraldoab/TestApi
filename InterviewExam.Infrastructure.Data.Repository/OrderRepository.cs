using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using InterviewExam.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewExam.Infrastructure.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly InterviewExamContext _context;
        public OrderRepository(InterviewExamContext context)
        {
            this._context = context;        
        }

        public Task<Order> CreateAsync(Order newOrder, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAsync(long customerId, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
