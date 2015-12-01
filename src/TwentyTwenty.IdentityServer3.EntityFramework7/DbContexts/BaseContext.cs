using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) 
            : base(options)
        { }
    }
}