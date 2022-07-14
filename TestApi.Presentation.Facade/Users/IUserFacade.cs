using TestApi.Application.Users.AddToken;
using TestApi.Application.Users.Register;
using TestApi.Query.Users.DTOs;

namespace TestApi.Presentation.Facade.Users;
public interface IUserFacade
{
    Task<bool> RegisterUser(RegisterUserCommand command);
    Task<bool> AddToken(AddUserTokenCommand command);
  
    
    Task<UserDTO?> GetUserById(long userId);
    Task<UserDTO> GetUserByName(string name);
    Task<UserTokenDTO?> GetTokenByJwtToken(string jwtToken);
    Task<List<UserDTO>> GetUsers();
}