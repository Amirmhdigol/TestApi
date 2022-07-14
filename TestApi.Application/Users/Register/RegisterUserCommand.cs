using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Application.Users.Register;
public class RegisterUserCommand : IRequest<bool>
{
    public RegisterUserCommand(string name, string password)
    {
        Name = name;
        Password = password;
    }
    public string Name { get; set; }
    public string Password { get; set; }
}