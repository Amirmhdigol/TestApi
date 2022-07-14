using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.TestUnit;
internal class UserBuilder
{
    private string _name = "FromTestUser";
    private string _password = "FromTestPassword";

    public User Build()
    {
        return new User(_name, _password);
    }

    public UserBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public UserBuilder SetPassword(string password)
    {
        _password = password;
        return this;
    }

    public UserBuilder AddToken(string hashjwt, DateTime dateTime)
    {
        var user = new User("aaaa", "12344321");
        user.AddToken(hashjwt, dateTime);
        return this;
    }
}