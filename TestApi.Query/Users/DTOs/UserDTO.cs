using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Common.Query;

namespace TestApi.Query.Users.DTOs;
public class UserDTO : BaseDTO
{
    public string Name { get; set; }
    public string Password { get; set; }
}