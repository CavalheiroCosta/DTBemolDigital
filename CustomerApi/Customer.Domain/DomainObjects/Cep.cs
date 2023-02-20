using Customer.Domain.Constants;
using Customer.Domain.Exceptions;
using Customer.Domain.Extensions;
using System.Text.RegularExpressions;

namespace Customer.Domain.DomainObjects
{
    public class Cep
    {
        public string Value { get; private set; }

        protected Cep() { }
        public Cep(string cep)
        {
            var cleanCep = cep.RemoveSpecialCharacteres();
            Value = IsValidCep(cleanCep) ? cleanCep :  throw new DomainException(ExpectedErrorMessages.InvalidCep);
        }

        private bool IsValidCep(string cep)
        {
            cep = cep.RemoveSpecialCharacteres();
            var validateRegex = new Regex(@"^[0-9]{8}$");
            return validateRegex.IsMatch(cep);
        }
    }
}
