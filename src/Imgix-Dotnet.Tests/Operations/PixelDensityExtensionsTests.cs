using Imgix_Dotnet.Operations.PixelDensity;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Operations
{
    [TestFixture]
    public class PixelDensityExtensionsTests : OperationsTests
    {
        public class DPR : PixelDensityExtensionsTests
        {
            [Test]
            public void Given_adouble__it_will_add_a_parameter_dpr_with_the_double_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.DPR(4.75), "dpr", "4.75");
            }
        }
    }
}