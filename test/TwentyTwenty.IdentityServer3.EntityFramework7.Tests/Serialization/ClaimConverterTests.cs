using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Tests.Serialization
{
    public class ClaimConverterTests
    {
        [Fact]
        public void CanSerializeAndDeserializeAClaim()
        {
            var claim = new Claim(Constants.ClaimTypes.Subject, "alice");

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new ClaimConverter());
            var json = JsonConvert.SerializeObject(claim, settings);

            claim = JsonConvert.DeserializeObject<Claim>(json, settings);
            Assert.Equal(Constants.ClaimTypes.Subject, claim.Type);
            Assert.Equal("alice", claim.Value);
        }
    }
}
