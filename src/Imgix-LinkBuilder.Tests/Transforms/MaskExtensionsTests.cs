using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.Mask;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class MaskExtensionsTests
    {
        private ImgixImage _image;

        [SetUp]
        public void MainFixtureInit()
        {
            _image = Imgix.NewImage(new ImgixOptions("sourceName"), "some/path/to/some/image.jpg");
        }

        private class EllipseMask : MaskExtensionsTests
        {
            [Test]
            public void It_should_add_a_mask_parameter_with_the_value_ellipse()
            {
                var result = _image.EllipseMask();
                ImgixImageAsserts.HasQueryParameter(result, "mask", "ellipse");
            }
        }

        private class Mask : MaskExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_parameter_mask_with_the_string_as_value()
            {
                const string value = "some/path/or/url.jpg?";
                var result = _image.Mask(value);
                ImgixImageAsserts.HasQueryParameter(result, "mask", value);
            }
        }
    }
}