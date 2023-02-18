using Customer.Domain.Interfaces.Repository;
using Customer.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Infra
{
    public static class Setup
    {
        public static void AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryAddressRepository, DeliveryAddressRepository>();
        }
    }
}