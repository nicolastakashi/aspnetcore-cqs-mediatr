using CQS.Api.Commands;
using FluentValidation;
using System;

namespace CQS.Api.Domain.Validations
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Birthday).NotNull().WithMessage("Birdth day is required");
            RuleFor(x => x.Birthday).Must(birthDay => new DateTime(birthDay.Year - 18, birthDay.Month, birthDay.Day) >= birthDay).WithMessage("Underage is not allowed");

        }
    }
}
