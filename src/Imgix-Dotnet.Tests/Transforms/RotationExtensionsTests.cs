using Imgix_Dotnet.Tests.TestHelpers;
using Imgix_Dotnet.Transforms.Rotation;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Transforms
{
    [TestFixture]
    public class RotationExtensionsTests : TransformsTests
    {
        public class Flip : RotationExtensionsTests
        {
            [Test]
            public void Given_a_string_value_a_flip_parameter_is_added_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Flip("hv"), "flip", "hv");
            }
        }

        public class Orientation : RotationExtensionsTests
        {
            [Test]
            public void Given_a_string_value_an_or_parameter_is_added_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Orientation("90"), "or", "90");
            }
        }

        public class Rotation : RotationExtensionsTests
        {
            [Test]
            public void Given_an_integer_value_a_rot_parameter_is_added_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Rotation(90), "rot", "90");
            }
        }
    }
}