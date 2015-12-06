using System.Linq;
using Imgix_Dotnet.Configuration.AppConfig;
using Imgix_Dotnet.Sharding;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Configuration.AppConfig
{
    [TestFixture]
    public class SourceElementTests
    {
        public class ToImgixSource
        {
            [Test]
            public void Should_create_ImgixSource_with_the_values_from_the_app_config()
            {
                var config = ImgixAppConfig.GetImgixSection();
                var source = config.Sources.First().ToImgixSource();
                Assert.AreEqual("testsource", source.Name);
            }
        }
    }
}