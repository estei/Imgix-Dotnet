using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class TrimExtensionsTests : TransformsTests
    {
        public class Trim : TrimExtensionsTests
        {
            public void Given_a_string_it_will_add_a_parameter_trim_with_the_value_of_the_string()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Trim("auto"), "trim", "auto");
            }
        }

        public class TrimColor : TrimExtensionsTests
        {
            public void Given_a_string_it_will_add_a_parameter_trimcolor_with_the_value_of_the_string()
            {
                ImgixImageAsserts.HasQueryParameter(Image.TrimColor("ff00ff"), "trimcolor", "ff00ff");
            }
        }

        public class TrimMeanDifference : TrimExtensionsTests
        {
            public void Given_an_integer_it_will_add_a_parameter_trimmd_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.TrimMeanDifference(5), "trimmd", "5");
            }
        }
    }
}