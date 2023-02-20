using Customer.Domain.Constants;
using Customer.Domain.Exceptions;
using Customer.Domain.Extensions;
using System.Text.RegularExpressions;

namespace Customer.Domain.DomainObjects
{
    public class Cpf
    {
        private readonly string[] _invalidCpfs = {
            "00000000000", "11111111111", "22222222222",
            "33333333333", "44444444444", "55555555555",
            "66666666666", "77777777777", "88888888888", "99999999999"
        };

        private readonly int[] _firstMultiplier = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly int[] _secondMultiplier = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public string Value { get; private set; }
        public Cpf(string value)
        {
            Value = IsValidCpf(value) ? value : throw new DomainException(ExpectedErrorMessages.InvalidOfficialDocument("CPF"));
        }

        private bool IsValidCpf(string cpf)
        {
            var cleanCpf = cpf.RemoveSpecialCharacteres();
            if (IsNotOnlyNumbersCpf(cleanCpf) || _invalidCpfs.Contains(cleanCpf))
                throw new DomainException(ExpectedErrorMessages.InvalidOfficialDocument("CPF"));

            var subCpf = cleanCpf.Substring(0, 9);

            var firstDigit = GetDigit(subCpf, _firstMultiplier);
            subCpf = subCpf + firstDigit;
            var digits = firstDigit + GetDigit(subCpf, _secondMultiplier);

            return cleanCpf.EndsWith(digits);

        }

        private bool IsNotOnlyNumbersCpf(string cpf)
        {
            var validateRegex = new Regex(@"^[0-9]{11}$");
            return !validateRegex.IsMatch(cpf);
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
