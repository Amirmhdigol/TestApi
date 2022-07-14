using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Common.Domain;

namespace TestApi.Domain;
public class UserToken : BaseEntity
{
    private UserToken()
    {

    }
    public UserToken(string hashedJwtToken, DateTime tokenExpireDate)
    {
        HashedJwtToken = hashedJwtToken;
        TokenExpireDate = tokenExpireDate;
        Guard();
    }
    public long UserId { get; internal set; }
    public string HashedJwtToken { get; private set; }
    public DateTime TokenExpireDate { get; private set; }

    public void Guard()
    {
        NullOrEmptyDomainDataException.CheckString(HashedJwtToken, nameof(HashedJwtToken));

        if (TokenExpireDate < DateTime.Now)
            throw new InvalidDomainDataException("Expire Date is Invalid");
    }

}