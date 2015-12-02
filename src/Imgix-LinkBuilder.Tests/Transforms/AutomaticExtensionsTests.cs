using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.Automatic;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class AutomaticExtensionsTests : TransformsTests
    {
        public class Auto : AutomaticExtensionsTests
        {
            [Test]
            public void Given_a_string_an_auto_parameter_is_added_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto("enhance"), "auto", "enhance");
            }
        }
    }
}