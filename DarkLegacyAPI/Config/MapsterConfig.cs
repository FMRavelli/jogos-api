using DarkLegacy.API.ViewModel;
using DarkLegacy.Core.Models;
using Mapster;
using System.Reflection;

namespace DarkLegacy.API.Config
{
    public static class MapsterConfig
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<Game, GameViewModel>
                .NewConfig()
                .Map(m => m.DsGenre, g => g.Genre != null ? g.Genre.DsGenre : string.Empty);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}