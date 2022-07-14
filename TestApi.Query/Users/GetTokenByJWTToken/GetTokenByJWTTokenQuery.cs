using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Query.Users.DTOs;

namespace TestApi.Query.Users.GetTokenByJWTToken;
public record GetTokenByJWTTokenQuery(string JwtToken) : IRequest<UserTokenDTO>;
