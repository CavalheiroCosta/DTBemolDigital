using Customer.Domain.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Requests
{
    public class CreateDeliveryAddressRequest
    {
        public string Cep { get; set; }
        public string AddressIdentifier { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public string AddressReference { get; set; }
    }

    public class CreateDeliveryAddressRequestValidator : AbstractValidator<CreateDeliveryAddressRequest>
    {
        public CreateDeliveryAddressRequestValidator()
        {
            RuleFor(p => p.Cep).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
            RuleFor(p => p.AddressIdentifier).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
            RuleFor(p => p.AddressNumber).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
            RuleFor(p => p.AddressComplement).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
        }
    }
}
