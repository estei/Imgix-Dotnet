using System;
using Imgix_LinkBuilder.Sharding;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Sharding
{
    [TestFixture]
    public class RoundRobinShardingStrategyTest
    {
        public class GetShardId : RoundRobinShardingStrategyTest
        {
            [Test]
            public void Given_an_empty_path_it_should_throw_ArgumentException()
            {
                var subject = new RoundRobinShardingStrategy();
                Assert.Throws<ArgumentException>(() => subject.GetShardId("", 1));
            }

            [Test]
            public void Given_a_null_path_it_should_throw_ArgumentException()
            {
                var subject = new RoundRobinShardingStrategy();
                Assert.Throws<ArgumentException>(() => subject.GetShardId(null, 1));
            }

            [Test]
            public void Given_the_same_path_twice_it_should_return_different_ids()
            {
                var subject = new RoundRobinShardingStrategy();
                var result = subject.GetShardId("any old string", 4);
                var result2 = subject.GetShardId("any old string", 4);
                Assert.AreNotEqual(result, result2);
            }

            [Test]
            public void Given_a_shardCount_of_1_it_should_always_return_0()
            {
                var subject = new RoundRobinShardingStrategy();
                var result = subject.GetShardId("any old string", 1);
                var result2 = subject.GetShardId("some other string", 1);
                Assert.AreEqual(0, result);
                Assert.AreEqual(0, result2);
            }

            [Test]
            public void Given_a_count_of_4_it_should_loop_between_0_and_3()
            {
                var subject = new RoundRobinShardingStrategy();
                for (var i = 0; i < 16; i++)
                {
                    var result = subject.GetShardId("any old string", 4);
                    Assert.True(4 > result && 0 <= result);
                }
            }
        }
    }
}