using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.Automatic;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class AutomaticExtensionsTests
    {
        private ImgixImage _image;

        [SetUp]
        public void MainFixtureInit()
        {
            _image = Imgix.NewImage(new ImgixOptions("sourceName"), "some/path/to/some/image.jpg");
        }

        public class Auto : AutomaticExtensionsTests
        {
            [Test]
            public void Given_a_string_an_auto_parameter_is_added_with_the_string_as_value()
            {
                var result = _image.Auto("enhance");
                ImgixImageAsserts.HasQueryParameter(result, "auto", "enhance");
            }
        }
    }
}