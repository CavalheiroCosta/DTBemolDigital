namespace Customer.Domain.Constants
{
    public static class ConfigurationErrorMessages
    {
        public static string ApiConfigurationNotFound(string api) => $"URL para {api} não encontrada nas configurações";
        public static string EmptyField(string field) => $"{field} deve ser informado.";
        public static string ExceptionError(string message) => $"Error message: {message}";
    }
}
