using Customer.Domain.Constants;
using Customer.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Customer.Domain.ValueObjects
{
    public class Cep
    {
        public string Number { get; }

        public Cep(string cep)
        {
            var onlyNumbersOfCep = GetOnlyNumbersOfCep(cep);
            Number = IsValidCep(onlyNumbersOfCep) ? onlyNumbersOfCep : throw new DomainException(ErrorMessages.InvalidCep()); 
        }

        private bool IsValidCep(string cep) 
        {
            var validateRegex = new Regex(@"^[0-9]{8}$");
            return validateRegex.IsMatch(cep);
        }

        private string GetOnlyNumbersOfCep(string cep) 
        {
            return cep.Trim().Replace(".",string.Empty).Replace("-", string.Empty);
        }
    }
}
