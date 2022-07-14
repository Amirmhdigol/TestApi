﻿using System;
namespace TestApi.Common.Domain.Bases;
public class BaseEntity
{
    public long Id { get; protected set; }
    public DateTime CreationDate { get; private set; }

    public BaseEntity()
    {
        CreationDate = DateTime.Now;
    }
}
