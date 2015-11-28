using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.PDF;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class PDFExtensionsTests : TransformsTests
    {
        [Test]
        public void Given_an_integer_it_should_add_a_parameter_page_with_the_value_of_the_integer()
        {
            ImgixImageAsserts.HasQueryParameter(Image.Page(1), "page", "1");
        }
    }
}