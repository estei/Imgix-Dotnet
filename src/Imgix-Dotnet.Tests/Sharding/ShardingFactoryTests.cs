using System;
using Imgix_Dotnet.Sharding;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Sharding
{
    [TestFixture]
    public class ShardingFactoryTests
    {
        public class GetStrategy : ShardingFactoryTests
        {
            [Test]
            public void Given_an_empty_name_it_should_throw_ArgumentException()
            {
                Assert.Throws<ArgumentException>(() => ShardingFactory.GetStrategy(""));
            }


            [Test]
            public void Given_a_name_that_does_not_exist_it_should_throw_ArgumentException()
            {
                Assert.Throws<ArgumentException>(() => ShardingFactory.GetStrategy("nonexistingshardingstrategy"));
            }

            [Test]
            public void Given_name_hash_it_should_return_a_HashShardingStrategy()
            {
                var result = ShardingFactory.GetStrategy("hash");
                Assert.IsInstanceOf<HashShardingStrategy>(result);
            }

            [Test]
            public void Given_name_none_it_should_return_a_NoShardingStrategy()
            {
                var result = ShardingFactory.GetStrategy("none");
                Assert.IsInstanceOf<NoShardingStrategy>(result);
            }

            [Test]
            public void Given_name_roundrobin_it_should_return_a_RoundRobinShardingStrategy()
            {
                var result = ShardingFactory.GetStrategy("roundrobin");
                Assert.IsInstanceOf<RoundRobinShardingStrategy>(result);
            }
        }
    }
}