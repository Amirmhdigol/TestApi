using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Presentation.Facade.Users;

namespace TestApi.Presentation.Facade;
public static class FacadeBootstraper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<IUserFacade, UserFacade>();
    }
}