namespace Customer.Domain.Constants
{
    public static class ConfigurationErrorMessages
    {
        public static string ApiConfigurationNotFound(string api) => $"URL for {api} not found in configurations";
    }
}
