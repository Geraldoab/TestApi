using InterviewExam.Application.Customers;
using InterviewExam.Application.Validators;
using InterviewExam.Domain.Interfaces.Repositories;
using InterviewExam.Domain.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;

namespace InterviewExam.Tests.Unit
{
    public class CustomerUnitTests
    {
        private readonly CustomerService _customerService;
        private readonly CustomerValidator _customValidator;

        public CustomerUnitTests(CustomerValidator customValidator)
        {
            var customerRepository = Substitute.For<ICustomerRepository>();
            customerRepository.GetAsync(Arg.Any<long>()).Returns(new Customer()
            {
                CustomerId = 1,
                Balance = 1,
                Name = "Test"
            });

            _customValidator = customValidator;

            _customerService = new CustomerService(customerRepository, _customValidator);
        }

        [Fact]
        public async Task Should_be_ok()
        {
            var customer = await _customerService.GetAsync(1);

            var result = _customValidator.TestValidate(customer!);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
