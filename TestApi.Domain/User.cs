using TestApi.Common.Domain;
namespace TestApi.Domain;

public class User : BaseEntity
{
    private User()
    {

    }

    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public string Name { get; private set; }
    public string Password { get; private set; }

    public List<UserToken> UserTokens { get; }

    public static User RegisterUser(string name, string password)
    {
        return new User(name, password);
    }

    public void AddToken(string hashedJwtToken, DateTime tokenExpireDate)
    {
        var token = new UserToken(hashedJwtToken, tokenExpireDate)
        {
            UserId = Id
        };
        UserTokens.Add(token);
    }
}