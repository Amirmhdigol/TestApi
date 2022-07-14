﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Common.Query;

namespace TestApi.Query.Users.DTOs;
public class UserTokenDTO : BaseDTO
{
    public long UserId { get; set; }
    public string HashedJwtToken { get; set; }
    public DateTime TokenExpireDate { get; set; }
}