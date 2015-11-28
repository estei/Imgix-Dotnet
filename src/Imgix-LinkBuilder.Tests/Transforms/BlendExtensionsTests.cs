using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class BlendExtensionsTests : TransformsTests
    {
        public class Blend : BlendExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_set_a_parameter_blend_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Blend("ff00ff"), "blend", "ff00ff");
            }
        }

        public class BlendMode : BlendExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_set_a_parameter_bm_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendMode("multiply"), "bm", "multiply");
            }
        }

        public class BlendAlign : BlendExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_set_a_parameter_ba_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendAlign("center"), "ba", "center");
            }
        }

        public class BlendAlpha : BlendExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_parameter_balpha_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendAlpha(10), "balpha", "10");
            }
        }

        public class BlendPadding : BlendExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_parameter_bp_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendPadding(10), "bp", "10");
            }
        }

        public class BlendWidth : BlendExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_parameter_bw_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendWidth(100), "bw", "100");
            }
        }

        public class BlendHeight : BlendExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_parameter_bh_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendHeight(100), "bh", "100");
            }
        }

        public class BlendFit : BlendExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_set_a_parameter_bf_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendFit("clamp"), "bf", "clamp");
            }
        }

        public class BlendCrop : BlendExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_set_a_parameter_bc_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendCrop("faces"), "bc", "faces");
            }
        }

        public class BlendSize : BlendExtensionsTests
        {
            [Test]
            public void Given_a_string_it_should_set_a_parameter_bc_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendSize("inherit"), "bs", "inherit");
            }
        }

        public class BlendXPosition : BlendExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_parameter_bx_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendXPosition(50), "bx", "50");
            }
        }

        public class BlendYPosition : BlendExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_should_add_a_parameter_by_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.BlendYPosition(50), "by", "50");
            }
        }
    }
}