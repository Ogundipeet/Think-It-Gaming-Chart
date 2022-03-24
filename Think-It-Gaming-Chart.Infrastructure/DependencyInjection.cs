using System;
using Microsoft.Extensions.DependencyInjection;
using Think_It_Gaming_Chart.Core.Repositories.Queries;
using Think_It_Gaming_Chart.Infrastructure.Repositories.Queries;

namespace Think_It_Gaming_Chart.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IGameQueryRepository, GameQueryRepository>();
            services.AddTransient<IUserQueryRepository, UserQueryRepository>();
            return services;
        }
    }
}
