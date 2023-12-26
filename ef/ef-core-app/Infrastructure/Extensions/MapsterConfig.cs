using Domain;
using Infrastructure.Models.Team;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class MapsterConfig
    {
        public static void AddMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Team, TeamDto>
                .NewConfig()
                .Map(x => x.CoachName, x => x.Name)
                ;
        }
    }
}
