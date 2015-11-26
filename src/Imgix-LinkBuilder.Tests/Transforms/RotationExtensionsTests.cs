using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.Rotation;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class RotationExtensionsTests
    {
        private ImgixImage _image;

        [SetUp]
        public void MainFixtureInit()
        {
            _image = Imgix.NewImage(new ImgixOptions("sourceName"), "some/path/to/some/image.jpg");
        }

        public class Flip : RotationExtensionsTests
        {
            [Test]
            public void Given_a_string_value_a_flip_parameter_is_added_with_the_string_as_value()
            {
                var result = _image.Flip("hv");
                ImgixImageAsserts.HasQueryParameter(result, "flip", "hv");
            }
        }

        public class Orientation : RotationExtensionsTests
        {
            [Test]
            public void Given_a_string_value_an_or_parameter_is_added_with_the_string_as_value()
            {
                var result = _image.Orientation("90");
                ImgixImageAsserts.HasQueryParameter(result, "or", "90");
            }
        }

        public class Rotation : RotationExtensionsTests
        {
            [Test]
            public void Given_an_integer_value_a_rot_parameter_is_added_with_the_integer_as_value()
            {
                var result = _image.Rotation(90);
                ImgixImageAsserts.HasQueryParameter(result, "rot", "90");
            }
        }
    }
}