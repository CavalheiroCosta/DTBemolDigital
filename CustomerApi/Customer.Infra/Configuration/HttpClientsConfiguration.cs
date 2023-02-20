using Customer.Domain.Constants;
using Customer.Infra.HttpClients.ViaCep;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using System.Net;

namespace Customer.Infra.Configuration
{
    public static class HttpClientsConfiguration
    {
        public static void ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var viaCepUrl = GetClientUri(configuration, "ViaCepApi");
            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5);
            services.AddHttpClient(nameof(IViaCepClient), client => client.BaseAddress = new Uri(viaCepUrl))
                            .AddPolicyHandler(GetRetryPolicy(delay))
                            .AddTypedClient(Refit.RestService.For<IViaCepClient>);
        }

        private static string GetClientUri(IConfiguration configuration, string api)
        {
            var url = configuration[api];
            return string.IsNullOrEmpty(url) ? throw new ArgumentNullException(nameof(configuration), ConfigurationErrorMessages.ApiConfigurationNotFound(api)) : url;
        }

        private static Func<IServiceProvider, HttpRequestMessage, IAsyncPolicy<HttpResponseMessage>> GetRetryPolicy(IEnumerable<TimeSpan> delay)
        {
            return (provider, msg) =>
            {
                return Policy.HandleResult<HttpResponseMessage>(message =>
                            message.StatusCode == HttpStatusCode.RequestTimeout ||
                            message.StatusCode == HttpStatusCode.GatewayTimeout ||
                            message.StatusCode == HttpStatusCode.InternalServerError)
                        .WaitAndRetryAsync(delay);
            };
        }
    }
}
