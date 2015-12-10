using Imgix_Dotnet.Operations.Noise;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Operations
{
    [TestFixture]
    public class NoiseExtensionsTests : OperationsTests
    {
        public class NoiseReductionBlur : NoiseExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_will_add_the_nr_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.NoiseReductionBlur(-100), "nr", "-100");
            }
        }

        public class NoiseReductionSharpen : NoiseExtensionsTests
        {
            [Test]
            public void Given_an_integer_it_will_add_the_nrs_parameter_with_the_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.NoiseReductionSharpen(100), "nrs", "100");
            }
        }
    }
}