using Customer.Domain.Interfaces.Repository;
using Customer.Infra.Configuration;
using Customer.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Infra
{
    public static class Setup
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureHttpClients(configuration);
            services.ConfigureContext();
            services.AddScoped<IDeliveryAddressRepository, DeliveryAddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}