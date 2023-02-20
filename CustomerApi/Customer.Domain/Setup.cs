using Customer.Domain.Handler;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Services;
using Customer.Domain.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

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

        public static void UseDomainExceptionHandler(this IApplicationBuilder app, ILogger logger) 
        {
            app.AddExceptionHandler(logger);
        }

    }
}