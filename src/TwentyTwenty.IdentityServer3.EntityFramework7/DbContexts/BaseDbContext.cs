using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public abstract class BaseDbContext : DbContext
    {
        public string Schema { get; protected set; }
    }
}