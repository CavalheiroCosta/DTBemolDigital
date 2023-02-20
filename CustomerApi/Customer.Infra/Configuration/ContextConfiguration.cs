using Customer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Customer.Infra.Configuration
{
    public static class ContextConfiguration
    {
        public static void ConfigureContext(this IServiceCollection services)
        {
            services.AddDbContext<CustomerContext>(options => options.UseInMemoryDatabase("ChallengeDb"));
        }
    }
}
