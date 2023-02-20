using Customer.Domain.Constants;
using Customer.Domain.Exceptions;

namespace Customer.Domain.DomainObjects
{
    public class Email
    {
        private readonly string[] _acceptedSuffix = { "com", "net", "org", "dev", "gov" };
        public string Value { get; private set; }
        public Email(string value)
        {
            Value = IsValidEmail(value) ? value.ToLower() : throw new DomainException(ExpectedErrorMessages.InvalidOfficialDocument("Email"));
        }

        private bool IsValidEmail(string email)
        {
            var dividedEmail = email.Split('@');
            if (dividedEmail.Length != 2) return false;

            var secondDivision = dividedEmail[1].Split(".");
            if (secondDivision.Length == 2 || secondDivision.Length == 3)
            {
                return _acceptedSuffix.Contains(secondDivision[1]);
            }

            return false;
        }
    }
}
