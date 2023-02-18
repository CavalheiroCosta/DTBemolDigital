namespace Customer.Domain.Constants
{
    public static class ExpectedErrorMessages
    {
        public static string InvalidCep() => "Cep informado é invalido.";
        public static string ExternalAddressNotFound(string cep) => $"Dados com o cep {cep} não foram encontrados";
    }
}
