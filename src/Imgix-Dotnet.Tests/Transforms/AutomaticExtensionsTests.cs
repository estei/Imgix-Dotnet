using Imgix_Dotnet.Tests.TestHelpers;
using Imgix_Dotnet.Transforms.Automatic;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Transforms
{
    [TestFixture]
    public class AutomaticExtensionsTests : TransformsTests
    {
        public class Auto : AutomaticExtensionsTests
        {
            [Test]
            public void Given_a_string_an_auto_parameter_is_added_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto("enhance"), "auto", "enhance");
            }

            [Test]
            public void Given_an_AutoTransform_Enhance_an_auto_parameter_enhance_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto(AutoTransform.Enhance), "auto", "enhance");
            }

            [Test]
            public void Given_an_AutoTransform_Redeye_an_auto_parameter_redeye_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto(AutoTransform.Redeye), "auto", "redeye");
            }

            [Test]
            public void Given_an_AutoTransform_Format_an_auto_parameter_format_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto(AutoTransform.Format), "auto", "format");
            }
        }
    }
}