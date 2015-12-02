using Imgix_Dotnet.Tests.TestHelpers;
using Imgix_Dotnet.Transforms.Border;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Transforms
{
    [TestFixture]
    public class BorderExtensionsTests : TransformsTests
    {
        public class Border : BorderExtensionsTests
        {
            [Test]
            public void Given_a_string_it_will_add_a_parameter_border_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Border("border=10,000"), "border", "border=10,000");
            }
        }
    }
}