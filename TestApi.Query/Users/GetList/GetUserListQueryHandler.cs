using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Infrastructure.Persistant.Dapper;
using TestApi.Query.Users.DTOs;


namespace TestApi.Query.Users.GetList;
public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDTO>>
{
    private readonly DapperContext _context;
    public GetUserListQueryHandler(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<UserDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var sql = $"select * from {_context.Users}";
        using var context = _context.CreateConnection();

        var result = await context.QueryAsync<UserDTO>(sql);
        return result.ToList();
    }
}