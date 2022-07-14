using MediatR;
using TestApi.Infrastructure.Persistant.Dapper;
using Dapper;
using TestApi.Query.Users.DTOs;

namespace TestApi.Query.Users.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
{
    private readonly DapperContext _dapperContext;
    public GetUserByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var sql = $"select top(1) * from {_dapperContext.Users} where Id=@id";
        using var context = _dapperContext.CreateConnection();
        var res = await context.QueryFirstOrDefaultAsync<UserDTO>(sql, new { id = request.UserId });
        return res;
    }
}