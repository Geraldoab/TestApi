using FluentValidation;
using InterviewExam.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewExam.CrossCutting.IoC.Providers
{
    internal static class ValidatorContainer
    {
        internal static void Register(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductValidator>();
        }
    }
}
