using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Application.Users.AddToken;
using TestApi.Application.Users.Register;
using TestApi.Common.Application;
using TestApi.Query.Users.DTOs;
using TestApi.Query.Users.GetById;
using TestApi.Query.Users.GetByName;
using TestApi.Query.Users.GetList;
using TestApi.Query.Users.GetTokenByJWTToken;

namespace TestApi.Presentation.Facade.Users;
public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<bool> AddToken(AddUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserTokenDTO?> GetTokenByJwtToken(string jwtToken)
    {
        var HashedJwtToken = Sha256Hasher.Hash(jwtToken);
        return await _mediator.Send(new GetTokenByJWTTokenQuery(HashedJwtToken));
    }

    public async Task<UserDTO?> GetUserById(long userId)
    {
        return await _mediator.Send(new GetUserByIdQuery(userId));
    }

    public async Task<UserDTO> GetUserByName(string name)
    {
        return await _mediator.Send(new GetUserByNameQuery(name));
    }

    public async Task<List<UserDTO>> GetUsers()
    {
        return await _mediator.Send(new GetUserListQuery());
    }

    public async Task<bool> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }
}