using InterviewExam.Application.Customers;
using InterviewExam.Application.Orders;
using InterviewExam.Application.Products;
using InterviewExam.CrossCutting.IoC.Providers;
using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Infrastructure.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewExam.CrossCutting.IoC
{
    public class InjectorContainer
    {
        public static void Register(IServiceCollection services, IConfiguration configuration, 
            bool isTest = false)
        {
            DbContainer.Register(services, configuration, isTest);
            AutoMapperContainer.Register(services);
            ValidatorContainer.Register(services);

            RegisterServices(services);
            RegisterRepositories(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
