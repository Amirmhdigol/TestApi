using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApi.Api.Infrastructure.JWT;
using TestApi.Api.ViewModels;
using TestApi.Application.Users.AddToken;
using TestApi.Application.Users.Register;
using TestApi.Common.Application;
using TestApi.Presentation.Facade.Users;
using TestApi.Query.Users.DTOs;

namespace TestApi.Api.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiversion}/[controller]")]
public class UserController : Controller
{
    private readonly IUserFacade _userFacade;
    private readonly IConfiguration _configuration;
    public UserController(IUserFacade userFacade, IConfiguration configuration)
    {
        _userFacade = userFacade;
        _configuration = configuration;
    }

    [HttpPost("Register")]
    public async Task<bool> Register(RegisterViewModel viewModel)
    {
        var res = await _userFacade.RegisterUser(new RegisterUserCommand(viewModel.Name, viewModel.Password));
        return res;
    }

    [HttpPost("Login")]
    public async Task<LoginResultDTO> Login(LoginViewModel viewModel)
    {
        var user = await _userFacade.GetUserByName(viewModel.Name);
        if (user == null)
            throw new Exception("user not found with this info");

        if (!Sha256Hasher.IsCompare(user.Password, viewModel.Password))
            throw new Exception("user not found with this info");

        var loginResult = await AddTokenAndBuildJwt(user);
        return loginResult;

    }

    [Authorize]
    [HttpGet]
    public virtual async Task<List<UserDTO>> GetUsers()
    {
        var res = await _userFacade.GetUsers();
        return res;
    }

    private async Task<LoginResultDTO> AddTokenAndBuildJwt(UserDTO user)
    {
        var token = JWTTokenBuilder.BuildToken(user, _configuration);

        var hashJwt = Sha256Hasher.Hash(token);

        var tokenResult = await _userFacade.AddToken(new AddUserTokenCommand(user.Id, hashJwt, DateTime.Now.AddDays(7)));

        if (tokenResult != true) throw new Exception("Token cannot be added");

        return new LoginResultDTO
        {
            Token = token,
        };
    }
}