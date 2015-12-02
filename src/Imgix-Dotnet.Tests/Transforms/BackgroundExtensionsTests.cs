using Imgix_Dotnet.Tests.TestHelpers;
using Imgix_Dotnet.Transforms.Background;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Transforms
{
    [TestFixture]
    public class BackgroundExtensionsTests : TransformsTests
    {
        public class BackgroundColor : BackgroundExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_set_a_parameter_bg_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BackgroundColor("ff00ff"), "bg", "ff00ff");
            }
        }
    }
}