using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewExam.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));  
        }

        public async Task<IEnumerable<Order>> GetAsync(int customerId, DateTime? startDate, DateTime? endDate, 
            CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAsync(customerId, startDate, endDate, cancellationToken); 
            return orders;
        }
    }
}
