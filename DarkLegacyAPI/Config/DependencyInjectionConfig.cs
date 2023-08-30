using DarkLegacy.Core.Application;
using DarkLegacy.Core.Data.Repositories;

namespace DarkLegacy.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<GameApp>();
            services.AddScoped<GameRepository>();
            services.AddScoped<GenreApp>();
            services.AddScoped<GenreRepository>();
        }
    }
}