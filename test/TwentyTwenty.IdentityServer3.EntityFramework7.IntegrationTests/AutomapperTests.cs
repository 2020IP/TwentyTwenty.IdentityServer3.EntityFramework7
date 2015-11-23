using AutoMapper;
using System.Collections.Generic;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;
using Xunit;
using Models = IdentityServer3.Core.Models;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.IntegrationTests
{
    public class AutomapperTests
    {
        [Fact]
        public void AutomapperConfigurationIsValid()
        {
            Models.Scope s = new Models.Scope() { };

            var e = Models.EntitiesMap.ToEntity(s);

            Scope s2 = new Scope()
            {
                ScopeClaims = new HashSet<ScopeClaim>()
            };
            var m = s2.ToModel();

            Mapper.AssertConfigurationIsValid();
        }
    }
}