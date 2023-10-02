using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using InterviewExam.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InterviewExam.Infrastructure.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly InterviewExamContext _context;
        public OrderRepository(InterviewExamContext context)
        {
            this._context = context;        
        }

        public async Task<Order> CreateAsync(Order newOrder, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAsync(int customerId, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken)
        {
            var a =  await _context.Orders
                .Include(i => i.OrderProducts)
                .ThenInclude(i => i.Product)
                .Where(x => x.CustomerId == customerId && ((startDate == null || x.OrderDate.Date >= startDate.Value.Date) && (endDate == null || x.OrderDate.Date <= endDate.Value.Date)))
                .ToListAsync(cancellationToken);

            return a;
        }
    }
}
