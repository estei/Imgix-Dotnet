using System.Linq;
using Imgix_Dotnet.Configuration.AppConfig;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Configuration.AppConfig
{
    [TestFixture]
    public class HostElementTests
    {
        public class HostName : HostElementTests
        {
            [Test]
            public void It_should_get_the_hostname_from_the_host_element()
            {
                var config = ImgixAppConfig.GetImgixSection();
                var hostname = config.Sources.First().Hosts.First().HostName;
                Assert.AreEqual("testsource", hostname);
            }
        }
    }
}