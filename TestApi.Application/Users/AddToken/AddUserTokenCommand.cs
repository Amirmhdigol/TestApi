using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Repository;

namespace TestApi.Application.Users.AddToken;
public class AddUserTokenCommand : IRequest<bool>
{
    public AddUserTokenCommand(long userId, string hashedJwtToken, DateTime tokenExpireDate)
    {
        UserId = userId;
        HashedJwtToken = hashedJwtToken;
        TokenExpireDate = tokenExpireDate;
    }
    public long UserId { get; private set; }
    public string HashedJwtToken { get; private set; }
    public DateTime TokenExpireDate { get; private set; }
}

public class AddUserTokenCommandHandler : IRequestHandler<AddUserTokenCommand, bool>
{
    private readonly IUserRepository _userRepository;
    public AddUserTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null) return false;

        user.AddToken(request.HashedJwtToken, request.TokenExpireDate);

        await _userRepository.Save();
        return true;
    }
}