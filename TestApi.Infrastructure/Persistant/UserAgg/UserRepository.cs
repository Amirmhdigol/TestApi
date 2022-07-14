using TestApi.Domain;
using TestApi.Domain.Repository;
using TestApi.Infrastructure.Utilities;

namespace TestApi.Infrastructure.Persistant.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TAContext context) : base(context)
        {
        }
    }
}
