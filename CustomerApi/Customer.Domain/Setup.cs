using Customer.Domain.Interfaces.Services;
using Customer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryAddressService, DeliveryAddressService>();
        }

    }
}