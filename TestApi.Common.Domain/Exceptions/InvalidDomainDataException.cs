﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class InvalidDomainDataException : BaseDomainException
    {
        public InvalidDomainDataException():base("Invalid Something")
        {

        }
        public InvalidDomainDataException(string message) : base(message)
        {

        }
    }
}
