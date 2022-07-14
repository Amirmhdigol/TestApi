using MediatR;
using TestApi.Common.Application;
using TestApi.Domain;
using TestApi.Domain.Repository;

namespace TestApi.Application.Users.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.Name, Sha256Hasher.Hash(request.Password));
        await _userRepository.AddAsync(user);
        await _userRepository.Save();
        return true;
    }
}