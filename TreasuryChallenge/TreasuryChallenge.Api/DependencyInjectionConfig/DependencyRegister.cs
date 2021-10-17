using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreasuryChallenge.Domain.Handlers;
using TreasuryChallenge.Domain.Repositories;
using TreasuryChallenge.Infra.Repositories;

namespace TreasuryChallenge.Api.DependencyInjectionConfig
{
    public static class DependencyRegister
    {
        public static void AddScoped(this IServiceCollection services, IConfiguration configuration)
        {
            #region Handlers
            services.AddTransient<TreasuryHandler, TreasuryHandler>();
            #endregion

            #region Repositories
            services.AddTransient<ITextFileRepository, TextFileRepository>();
            #endregion
        }
    }
}
