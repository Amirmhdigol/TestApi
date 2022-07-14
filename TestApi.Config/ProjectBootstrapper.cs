using Microsoft.Extensions.DependencyInjection;
using TestApi.Infrastructure;
using TestApi.Presentation.Facade;
using TestApi.Query.Users.GetList;
using MediatR;
using TestApi.Application.Users.Register;

namespace TestApi.Config;
public static class ProjectBootstrapper
{
    public static void RegisterDependency(this IServiceCollection services, string connectionString)
    { 
        InfrastructureBootstrapper.Init(services, connectionString);
        FacadeBootstraper.InitFacadeDependency(services);

        services.AddMediatR(typeof(GetUserListQuery).Assembly);
        services.AddMediatR(typeof(RegisterUserCommand).Assembly);
    }
}