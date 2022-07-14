
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TestApi.Api.Utilities;
using TestApi.Presentation.Facade.Users;

namespace TestApi.Api.Infrastructure.JWT;
public class CustomJwtValidation
{
    private readonly IUserFacade _facade;

    public CustomJwtValidation(IUserFacade facade)
    {
        _facade = facade;
    }

    public async Task Validate(TokenValidatedContext context)
    {
        var userId = context.Principal.GetUserId();
        var jwtTtoken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var token = _facade.GetTokenByJwtToken(jwtTtoken);

        if (token == null) { context.Fail("Token not Found"); return; }

        var user = await _facade.GetUserById(userId);

        if (user == null) { context.Fail("Token not Found"); return; }
    }
}