using Imgix_Dotnet.Operations.Stylize;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Operations
{
    [TestFixture]
    public class StylizeExtensionsTests : OperationsTests
    {
        public class Blur : StylizeExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_blur_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Blur(500), "blur", "500");
            }
        }

        public class HalfTone : StylizeExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_htn_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.HalfTone(50), "htn", "50");
            }
        }

        public class Monochrome : StylizeExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_add_a_mono_parameter_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Monochrome("aa3498db"), "mono", "aa3498db");
            }
        }

        public class Pixellate : StylizeExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_px_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Pixellate(50), "px", "50");
            }
        }

        public class SepiaTone : StylizeExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_sepia_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.SepiaTone(50), "sepia", "50");
            }
        }
    }
}