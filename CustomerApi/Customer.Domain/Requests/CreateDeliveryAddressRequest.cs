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
        public string Identifier { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }
    }

    public class CreateDeliveryAddressRequestValidator : AbstractValidator<CreateDeliveryAddressRequest>
    {
        public CreateDeliveryAddressRequestValidator()
        {
            RuleFor(p => p.Cep).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
            RuleFor(p => p.Identifier).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
            RuleFor(p => p.Number).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
            RuleFor(p => p.Complement).NotEmpty().WithMessage(ConfigurationErrorMessages.EmptyField("Name"));
        }
    }
}
