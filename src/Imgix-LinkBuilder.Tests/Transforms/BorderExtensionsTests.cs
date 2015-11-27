using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.Border;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class BorderExtensionsTests : TransformsTests
    {
        public class Border : BorderExtensionsTests
        {
            [Test]
            public void Given_a_string_it_will_add_a_parameter_border_with_the_string_as_value()
            {
                var result = Image.Border("border=10,000");
                ImgixImageAsserts.HasQueryParameter(result, "border", "border=10,000");
            }
        }
    }
}