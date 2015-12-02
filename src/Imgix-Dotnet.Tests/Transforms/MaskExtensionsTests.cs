using Imgix_Dotnet.Tests.TestHelpers;
using Imgix_Dotnet.Transforms.Mask;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Transforms
{
    [TestFixture]
    public class MaskExtensionsTests : TransformsTests
    {
        private class EllipseMask : MaskExtensionsTests
        {
            [Test]
            public void It_should_add_a_mask_parameter_with_the_value_ellipse()
            {
                ImgixImageAsserts.HasQueryParameter(Image.EllipseMask(), "mask", "ellipse");
            }
        }

        private class Mask : MaskExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_parameter_mask_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Mask("some/path/or/url.jpg?"), "mask", "some/path/or/url.jpg?");
            }
        }
    }
}