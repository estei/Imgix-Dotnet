using System;
using System.Linq;
using Imgix_Dotnet.Sharding;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Sharding
{
    [TestFixture]
    public class HashShardingStrategyTests
    {
        public class GetShardId : HashShardingStrategyTests
        {
            [Test]
            public void Given_a_path_and_a_shardcount_of_four_it_should_return_a_value_between_0_and_3()
            {
                //Since we don't "know" the implementation of the hash approximate a test by throwing a bunch of random strings at it.
                //Not great but it gives me enough confidence.
                for (var i = 0; i < 10000; i++)
                {
                    var subject = new HashShardingStrategy();
                    var result = subject.GetShardId(RandomString(), 4);
                    Assert.True(4 > result && 0 <= result);
                }
            }

            public static string RandomString()
            {
                var random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvowxyz0123456789/.";
                var length = random.Next(1, 200);
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            [Test]
            public void Given_the_same_path_twice_it_should_return_the_same_id()
            {
                var subject = new HashShardingStrategy();
                var result = subject.GetShardId("any old string", 4);
                var result2 = subject.GetShardId("any old string", 4);
                Assert.AreEqual(result, result2);
            }

            [Test]
            public void Given_a_shardCount_of_1_it_should_always_return_0()
            {
                var subject = new HashShardingStrategy();
                var result = subject.GetShardId("any old string", 1);
                var result2 = subject.GetShardId("some other string", 1);
                Assert.AreEqual(0, result);
                Assert.AreEqual(0, result2);
            }

            [Test]
            public void Given_an_empty_path_it_should_throw_ArgumentException()
            {
                var subject = new HashShardingStrategy();
                Assert.Throws<ArgumentException>(() => subject.GetShardId("", 1));
            }

            [Test]
            public void Given_a_null_path_it_should_throw_ArgumentException()
            {
                var subject = new HashShardingStrategy();
                Assert.Throws<ArgumentException>(() => subject.GetShardId(null, 1));
            }
        }
    }
}