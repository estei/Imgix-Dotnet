using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.Noise;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class NoiseExtensionsTests : TransformsTests
    {
        public class NoiseReductionBlur : NoiseExtensionsTests
        {
            public void Given_an_integer_it_will_add_the_nr_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.NoiseReductionBlur(-100), "nr", "-100");
            }
        }

        public class NoiseReductionSharpen : NoiseExtensionsTests
        {
            public void Given_an_integer_it_will_add_the_nrs_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.NoiseReductionSharpen(100), "nr", "100");
            }
        }
    }
}