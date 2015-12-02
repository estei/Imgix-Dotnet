using Imgix_Dotnet.Tests.TestHelpers;
using Imgix_Dotnet.Transforms.Trim;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Transforms
{
    [TestFixture]
    public class TrimExtensionsTests : TransformsTests
    {
        public class Trim : TrimExtensionsTests
        {
            [Test]
            public void Given_a_string_it_will_add_a_parameter_trim_with_the_value_of_the_string()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Trim("auto"), "trim", "auto");
            }
        }

        public class TrimColor : TrimExtensionsTests
        {
            [Test]
            public void Given_a_string_it_will_add_a_parameter_trimcolor_with_the_value_of_the_string()
            {
                ImgixImageAsserts.HasQueryParameter(Image.TrimColor("ff00ff"), "trimcolor", "ff00ff");
            }
        }

        public class TrimMeanDifference : TrimExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_will_add_a_parameter_trimmd_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.TrimMeanDifference(5), "trimmd", "5");
            }
        }

        public class TrimStandardDeviation : TrimExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_will_add_a_parameter_trimsd_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.TrimStandardDeviation(5), "trimsd", "5");
            }
        }
        public class TrimTolerance : TrimExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_will_add_a_parameter_trimtol_with_the_value_of_the_integer()
            {
                ImgixImageAsserts.HasQueryParameter(Image.TrimTolerance(5), "trimtol", "5");
            }
        }
    }
}