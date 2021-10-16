using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreasuryChallenge.Domain.Handlers;

namespace TreasuryChallenge.Api.DependencyInjectionConfig
{
    public static class DependencyRegister
    {
        public static void AddScoped(this IServiceCollection services, IConfiguration configuration)
        {
            #region Handlers
            services.AddTransient<TreasuryHandler, TreasuryHandler>();
            #endregion
        }
    }
}
