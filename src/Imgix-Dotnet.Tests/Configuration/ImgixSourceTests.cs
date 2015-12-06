using System;
using Imgix_Dotnet.Configuration;
using Imgix_Dotnet.Sharding;
using Moq;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Configuration
{
    [TestFixture]
    public class ImgixSourceTests
    {
        public class Ctor : ImgixSourceTests
        {
            [Test]
            public void Given_a_host_without_dots_sanitize_to_imgix_net_hostname()
            {
                var subject = new ImgixSource("testhost", "testhost");
                var result = subject.GetUrl("hey/hey.jpg");
                Assert.True(result.ToString().Contains("testhost.imgix.net"));
            }

            [Test]
            public void Given_an_empty_name_it_should_throw_ArgumentException()
            {
                Assert.Throws<ArgumentException>(
                    // ReSharper disable ObjectCreationAsStatement
                    () => new ImgixSource("", "Token", new[] {"host"}, new NoShardingStrategy()));
                    // ReSharper restore ObjectCreationAsStatement
            }

            [Test]
            public void Given_null_for_secureUrlToken_it_should_throw_ArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(
                    // ReSharper disable ObjectCreationAsStatement
                    () => new ImgixSource("Name", null, new[] { "host" }, false, new NoShardingStrategy()));
                // ReSharper restore ObjectCreationAsStatement
            }

            [Test]
            public void Given_an_empty_hosts_it_should_throw_ArgumentException()
            {
                Assert.Throws<ArgumentException>(
                    // ReSharper disable ObjectCreationAsStatement
                    () => new ImgixSource("name", new string[] {}, false, new NoShardingStrategy()));
                // ReSharper restore ObjectCreationAsStatement
            }

            [Test]
            public void Given_null_for_shardingStrategy_it_should_throw_ArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(
                    // ReSharper disable ObjectCreationAsStatement
                    () => new ImgixSource("Name", "", new[] { "host" }, false, null));
                // ReSharper restore ObjectCreationAsStatement
            }
        }

        public class GetUrl : ImgixSourceTests
        {
            [Test]
            public void Given_a_path_it_should_return_a_url_with_that_path()
            {
                var subject = new ImgixSource("testhost", "testhost.imgix.net");
                var result = subject.GetUrl("hey/hey.jpg");
                Assert.True(result.ToString().Contains("hey/hey.jpg"));
            }

            [Test]
            public void Given_a_path_it_should_request_the_shardId_from_the_shardingStrategy()
            {
                //Arrange
                var mockShardingStrategy = new Mock<IShardingStrategy>();
                mockShardingStrategy.Setup(s => s.GetShardId(It.IsAny<string>(), 1)).Returns(0);
                var subject = new ImgixSource("testhost", "" , new []{ "testhost.imgix.net" }, true, mockShardingStrategy.Object);
                //Act
                subject.GetUrl("testhost.imgix.net");
                //Assert
                mockShardingStrategy.VerifyAll();
            }

            [Test]
            public void Given_an_empty_path_it_should_throw_ArgumentException()
            {
                var subject = new ImgixSource("testhost", "testhost");
                Assert.Throws<ArgumentException>(() => subject.GetUrl(""));
            }
        }
    }
}