using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TreasuryChallenge.Api.DependencyInjectionConfig
{
    public static class DependencyRegister
    {
        public static void AddScoped(this IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
