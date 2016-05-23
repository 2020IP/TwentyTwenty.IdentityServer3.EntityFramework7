﻿using Microsoft.EntityFrameworkCore;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) 
            : base(options)
        { }
    }
}