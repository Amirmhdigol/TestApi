using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Presentation.Facade.Users;
using TestApi.Query.Users.DTOs;

namespace TestApi.Api.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiversion}/[controller]")]
public class UserController : TestApi.Api.Controllers.V1.UserController
{
    public UserController(IUserFacade userFacade, IConfiguration configuration) : base(userFacade, configuration)
    {
    }

    public override Task<List<UserDTO>> GetUsers()
    {
        return base.GetUsers();
    }
}