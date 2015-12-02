using Imgix_Dotnet.Tests.TestHelpers;
using Imgix_Dotnet.Transforms.Watermark;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Transforms
{
    [TestFixture]
    public class WatermarkExtensionsTests : TransformsTests
    {
        public class Mark : WatermarkExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_mark_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Mark("watermark.png"), "mark", "watermark.png");
            }
        }

        public class MarkAlign : WatermarkExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_markalign_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkAlign("top"), "markalign", "top");
            }
        }

        public class MarkAlpha : WatermarkExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_markalpha_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkAlpha(50), "markalpha", "50");
            }
        }

        public class MarkBase : WatermarkExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_markbase_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkBase("https://assets.imgix.net/"), "markbase", "https://assets.imgix.net/");
            }
        }

        public class MarkFit : WatermarkExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_markfit_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkFit("clip"), "markfit", "clip");
            }
        }

        public class MarkHeight : WatermarkExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_markh_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkHeight(50), "markh", "50");
            }

            [Test]
            public void Given_a_double_it_should_add_a_markh_parameter_with_the_double_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkHeight(0.5), "markh", "0.5");
            }
        }

        public class MarkPadding : WatermarkExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_markpad_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkPadding(10), "markpad", "10");
            }
        }

        public class MarkScale : WatermarkExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_markscale_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkScale(25), "markscale", "25");
            }
        }

        public class MarkWidth : WatermarkExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_markw_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkWidth(50), "markw", "50");
            }

            [Test]
            public void Given_a_double_it_should_add_a_markw_parameter_with_the_double_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkWidth(0.5), "markw", "0.5");
            }
        }

        public class MarkXPosition : WatermarkExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_markx_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkXPosition(15), "markx", "15");
            }
        }

        public class MarkYPosition : WatermarkExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_marky_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.MarkYPosition(15), "marky", "15");
            }
        }
    }
}