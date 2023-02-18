using Customer.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Exceptions
{
    public class ExternalAddressNotFoundException : DomainException
    {
        public ExternalAddressNotFoundException(string cep) : base(ExpectedErrorMessages.ExternalAddressNotFound(cep))
        {
        }
    }
}
