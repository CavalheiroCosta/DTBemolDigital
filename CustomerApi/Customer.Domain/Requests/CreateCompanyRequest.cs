using Customer.Domain.Constants;
using FluentValidation;

namespace Customer.Domain.Requests
{
    public class CreateCompanyRequest
    {
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public CreateDeliveryAddressRequest DeliveryAddress { get; set; }
    }

    public class CreateCompanyRequestValidator : AbstractValidator<CreateCompanyRequest>
    {
        public CreateCompanyRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
            RuleFor(p => p.CorporateName).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("CorporateName"));
            RuleFor(p => p.Cnpj).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Cnpj"));
            RuleFor(p => p.Email).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Email"));
            RuleFor(p => p.DeliveryAddress).SetValidator(new CreateDeliveryAddressRequestValidator());
        }
    }
}
