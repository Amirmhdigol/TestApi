using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Repository;
using TestApi.Infrastructure.Persistant;
using TestApi.Infrastructure.Persistant.Dapper;
using TestApi.Infrastructure.Persistant.UserAgg;

namespace TestApi.Infrastructure;
public static class InfrastructureBootstrapper
{
    public static void Init(this IServiceCollection services, string connectionString)
    {
        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient(_ => new DapperContext(connectionString));
        services.AddDbContext<TAContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}