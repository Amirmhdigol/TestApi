using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Common.Domain.Repository;

namespace TestApi.Domain.Repository;
public interface IUserRepository : IBaseRepository<User>
{

}
