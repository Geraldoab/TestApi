using FluentValidation;
using InterviewExam.Domain.Models;

namespace InterviewExam.Application.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.Balance).GreaterThanOrEqualTo(0).When(customer => customer != null);
            RuleFor(p => p.CustomerId).GreaterThan(0).When(customer => customer != null);
            RuleFor(p => p.Name).NotEmpty().When(customer => customer != null);
        }
    }
}
