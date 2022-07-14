using FluentAssertions;
using MediatR;
using NSubstitute;
using TestApi.Application.Users.Register;
using TestApi.Domain.Repository;
using TestApi.Presentation.Facade.Users;
using Xunit;

namespace TestApi.Application.TestUnit;
public class UserTest
{
    readonly IUserFacade _userFacade;
    readonly IUserRepository _userRepository;

    public UserTest()
    {
        _userFacade = Substitute.For<IUserFacade>();                        
        _userRepository = Substitute.For<IUserRepository>();
    }

}