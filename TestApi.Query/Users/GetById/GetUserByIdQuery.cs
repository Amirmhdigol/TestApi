using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain.Repository;
using TestApi.Query.Users.DTOs;

namespace TestApi.Query.Users.GetById;
public record GetUserByIdQuery(long UserId) : IRequest<UserDTO>;
