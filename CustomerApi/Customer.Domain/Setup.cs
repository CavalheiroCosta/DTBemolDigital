using Customer.Domain.Interfaces.Services;
using Customer.Domain.Services;
using Customer.Domain.Util;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<ICacheUtil, CacheUtil>();
        }

    }
}