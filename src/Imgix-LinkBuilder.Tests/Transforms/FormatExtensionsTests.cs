using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.Format;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class FormatExtensionsTests : TransformsTests
    {
        public class ClientHints : FormatExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_ch_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.ClientHints("Width,DPR"), "ch", "Width,DPR");
            }
        }

        public class ChromaSubsampling : FormatExtensionsTests
        {
            [Test]
            public void Given_a_integer_it_should_add_a_chromasub_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.ChromaSubsampling(422), "chromasub", "422");
            }
        }

        public class ColorQuantization : FormatExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_colorquant_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.ColorQuantization(128), "colorquant", "128");
            }
        }

        public class Download : FormatExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_ch_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Download("medium"), "dl", "medium");
            }
        }

        public class DPI : FormatExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_colorquant_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.DPI(128), "dpi", "128");
            }
        }

        public class OutputFormat : FormatExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_ch_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.OutputFormat("png"), "fm", "png");
            }
        }

        public class Lossless : FormatExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_lossless_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Lossless("true"), "lossless", "true");
            }
        }

        public class Quality : FormatExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_quality_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Quality(50), "q", "50");
            }
        }
    }
}