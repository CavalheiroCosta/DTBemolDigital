﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Customer.Domain.Constants
{
    public static class ExpectedErrorMessages
    {
        public static string InvalidOfficialDocument(string documentType) => $"{documentType} informado é invalido.";
        public static string InvalidCep() => "Cep informado é invalido.";
        public static string ExternalAddressNotFound(string cep) => $"Dados com o cep {cep} não foram encontrados";
        public static string DuplicateDataWithTheData(string data) => $"Ja há um Customer com {data} cadastrado";
    }
}
