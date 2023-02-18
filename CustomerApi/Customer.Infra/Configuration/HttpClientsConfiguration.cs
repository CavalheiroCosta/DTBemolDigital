using Customer.Domain.Constants;
using Customer.Infra.HttpClients.ViaCep;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Customer.Infra.Configuration
{
    public static class HttpClientsConfiguration
    {
        public static void ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddRefitClient<IViaCepClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(GetClientUri(configuration, "ViaCepApi")));
        }

        private static string GetClientUri(IConfiguration configuration, string api) 
        {
            var url = configuration[api];
            return string.IsNullOrEmpty(url) ? throw new ArgumentNullException(nameof(configuration), ConfigurationErrorMessages.ApiConfigurationNotFound(api)) : url;
        }
    }
}
