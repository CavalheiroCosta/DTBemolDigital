using Customer.Domain.Constants;
using Customer.Domain.Exceptions;
using Customer.Domain.Extensions;
using System.Text.RegularExpressions;

namespace Customer.Domain.DomainObjects
{
    public class Cnpj
    {
        private readonly string[] _invalidCnpjs = {
             "00000000000000", "11111111111111", "22222222222222", "33333333333333",
            "44444444444444", "55555555555555", "66666666666666", "77777777777777",
            "88888888888888", "99999999999999",
        };

        private readonly int[] _firstMultiplier = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly int[] _secondMultiplier = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public string Value { get; private set; }

        protected Cnpj() { }
        public Cnpj(string cnpj) {
            Value = IsValidCnpj(cnpj) ? cnpj : throw new DomainException(ExpectedErrorMessages.InvalidOfficialDocument("CNPJ"));
        }

        private bool IsValidCnpj(string cnpj)
        {
            var cleanCnpj = cnpj.RemoveSpecialCharacteres();
            if (IsNotOnlyNumbersCpf(cleanCnpj) || _invalidCnpjs.Contains(cleanCnpj))
                throw new DomainException(ExpectedErrorMessages.InvalidOfficialDocument("CNPJ"));

            var subCnpj = cleanCnpj.Substring(0, 12);

            var firstDigit = GetDigit(subCnpj, _firstMultiplier);
            subCnpj = subCnpj + firstDigit;
            var digits = firstDigit + GetDigit(subCnpj, _secondMultiplier);

            return cleanCnpj.EndsWith(digits);

        }

        private bool IsNotOnlyNumbersCpf(string cnpj)
        {
            var validateRegex = new Regex(@"^[0-9]{14}$");
            return !validateRegex.IsMatch(cnpj);
        }

        private string GetDigit(string numbers, int[] multipliers)
        {
            var total = 0;
            for (int i = 0; i < multipliers.Length; i++)
                total += int.Parse(numbers[i].ToString()) * multipliers[i];

            var remainder = total % 11;
            return remainder < 2 ? "0" : (11 - remainder).ToString();
        }
    }
}
