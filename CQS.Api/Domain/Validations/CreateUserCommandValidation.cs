using System;
using CQS.Api.Commands;
using FluentValidation;

namespace CQS.Api.Domain.Validations
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Birthday).NotNull().WithMessage("Birdth day is required");
            RuleFor(x => x.Birthday).Must(y => DateTime.Now.AddYears(-18).Year >= y.Year).WithMessage("Underage is not allowed");

        }
    }
}
