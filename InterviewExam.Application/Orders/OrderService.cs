using InterviewExam.Application.Customers;
using InterviewExam.Application.Products;
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
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public OrderService(IOrderRepository orderRepository, ICustomerService customerService, IProductService productService)
        {
            this._orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this._customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this._productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<Order> CreateAsync(Order newOrder, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetAsync(newOrder.CustomerId, cancellationToken);

            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            if(newOrder == null)
                throw new ArgumentNullException(nameof(newOrder));

            if (newOrder.OrderProducts == null)
                throw new ArgumentNullException(nameof(newOrder.OrderProducts));

            var totalPrice = 0.0;



            foreach (var selectedProduct in newOrder.OrderProducts)
            {
                var currentProduct = await _productService.GetByIdAsync(selectedProduct.ProductId, cancellationToken);
                if (currentProduct == null)
                    throw new Exception($"Product not found with id { selectedProduct.ProductId }");

                totalPrice += currentProduct.Price * selectedProduct.Quantity;

                await _productService.UpdateStockAsync(currentProduct.ProductId, currentProduct.Quantity - selectedProduct.Quantity, cancellationToken);

                /*if (lineItems.Any(x => x.ProductId == product.ProductId))
                {
                    var lineItem = lineItems.First(w => w.ProductId == product.ProductId);
                    lineItem.QuantityPurchased += item.Quantity;
                    lineItem.TotalCost += item.Quantity * product.Price;
                }
                else
                {
                    lineItems.Add(new LineItemResponse
                    {
                        ProductId = product.ProductId,
                        ProductName = product.Name,
                        QuantityPurchased = item.Quantity,
                        TotalCost = totalPrice
                    });
                }*/
            }


            return new Order();
        }

        public async Task<IEnumerable<Order>> GetAsync(int customerId, DateTime? startDate, DateTime? endDate, 
            CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAsync(customerId, startDate, endDate, cancellationToken); 
            return orders;
        }
    }
}
