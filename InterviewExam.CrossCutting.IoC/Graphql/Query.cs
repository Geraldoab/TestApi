using InterviewExam.Domain.Models;
using InterviewExam.Infrastructure.Data.Context;

namespace InterviewExam.CrossCutting.IoC.Graphql
{
    public class Query
    {
        public IQueryable<Customer> GetCustomers([Service] InterviewExamContext context)
        {
            return context.Customers;
        }

        public IQueryable<Order> GetOrders([Service] InterviewExamContext context)
        {
            return context.Orders;
        }

        public IQueryable<OrderProduct> GetOrderProducts([Service] InterviewExamContext context)
        {
            return context.OrderProducts;
        }

        public IQueryable<Product> GetProducts([Service] InterviewExamContext context)
        {
            return context.Products;
        }
    }
}
