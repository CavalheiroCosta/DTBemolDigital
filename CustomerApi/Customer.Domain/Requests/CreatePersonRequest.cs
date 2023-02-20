
using Customer.Domain.Constants;
using FluentValidation;

namespace Customer.Domain.Requests
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public CreateDeliveryAddressRequest DeliveryAddress { get; set; }

    }

    public class CreateCustomerPersonRequestValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreateCustomerPersonRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("BirthDate"));
            RuleFor(p => p.Cpf).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("CPF"));
            RuleFor(p => p.Email).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Email"));
            RuleFor(p => p.DeliveryAddress).SetValidator(new CreateDeliveryAddressRequestValidator());

        }
    }
}

