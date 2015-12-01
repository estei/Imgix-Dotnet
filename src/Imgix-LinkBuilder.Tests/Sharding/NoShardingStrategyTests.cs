using System;
using Imgix_LinkBuilder.Sharding;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Sharding
{
    [TestFixture]
    public class NoShardingStrategyTests
    {
        public class GetShardId : NoShardingStrategyTests
        {
            [Test]
            public void Given_a_path_it_should_return_0()
            {
                var subject = new NoShardingStrategy();
                var result = subject.GetShardId("any old string", 4);
                Assert.AreEqual(0, result);
            }

            [Test]
            public void Given_an_empty_path_it_should_throw_ArgumentException()
            {
                var subject = new NoShardingStrategy();
                Assert.Throws<ArgumentException>(() => subject.GetShardId("", 1));
            }

            [Test]
            public void Given_a_null_path_it_should_throw_ArgumentException()
            {
                var subject = new NoShardingStrategy();
                Assert.Throws<ArgumentException>(() => subject.GetShardId(null, 1));
            }
        }
    }
}