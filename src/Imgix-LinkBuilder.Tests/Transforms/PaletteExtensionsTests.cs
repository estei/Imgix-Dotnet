using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class PaletteExtensionsTests : TransformsTests
    {
        public class Colors : PaletteExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_parameter_colors_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Colors(1), "colors", "1");
            }
        }

        public class Palette : PaletteExtensionsTests
        {
            [Test]
            public void Given_a_string_it_will_add_a_parameter_palette_with_the_value_of_the_string()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Palette("json"), "palette", "json");
            }
        }

        public class CSSPrefix : PaletteExtensionsTests
        {
            [Test]
            public void Given_a_string_it_will_add_a_parameter_prefix_with_the_value_of_the_string()
            {
                ImgixImageAsserts.HasQueryParameter(Image.CSSPrefix("ThisIsAPrefix"), "prefix", "ThisIsAPrefix");
            }
        }
    }
}