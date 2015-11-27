using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.PixelDensity;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class PixelDensityExtensionsTests
    {
        private ImgixImage _image;

        [SetUp]
        public void MainFixtureInit()
        {
            _image = Imgix.NewImage(new ImgixOptions("sourceName"), "some/path/to/some/image.jpg");
        }

        public class DPR : PixelDensityExtensionsTests
        {
            [Test]
            public void Given_adouble__it_will_add_a_parameter_dpr_with_the_double_as_value()
            {
                var result = _image.DPR(4.75);
                ImgixImageAsserts.HasQueryParameter(result, "dpr", "4.75");
            }
        }
    }
}