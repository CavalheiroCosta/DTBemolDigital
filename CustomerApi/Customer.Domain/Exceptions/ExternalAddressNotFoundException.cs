using Customer.Domain.Constants;

namespace Customer.Domain.Exceptions
{
    public class ExternalAddressNotFoundException : Exception
    {
        public ExternalAddressNotFoundException(string cep) : base(ExpectedErrorMessages.ExternalAddressNotFound(cep))
        {
        }
    }
}
