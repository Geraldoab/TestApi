using FluentValidation;
using FluentValidation.Results;
using InterviewExam.Application.Validators;
using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewExam.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<Customer> _customerValidator;
        public CustomerService(ICustomerRepository customerRepository, IValidator<Customer> customerValidator)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _customerValidator = customerValidator;
        }

        public async Task<Customer?> GetAsync(long customerId, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(customerId, cancellationToken);

            var results = await _customerValidator.ValidateAsync(customer);
            if(!results.IsValid)
            {
                foreach(var error in results.Errors)
                {
                    Console.WriteLine($"{error.PropertyName} => {error.ErrorMessage}");
                }
            }

            return customer;
        }

        public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken)
        {
            return await _customerRepository.CreateAsync(customer, cancellationToken);
        }

        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _customerRepository.UpdateAsync(customer, cancellationToken);
        }
    }
}
