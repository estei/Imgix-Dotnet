using System.Net.Mime;
using Imgix_Dotnet.Configuration;
using Imgix_Dotnet.Macros;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Macros
{
    [TestFixture]
    public class FocalExtensionsTests
    {
        internal ImgixImage Image;

        [SetUp]
        public void MainFixtureInit()
        {
            Image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("sourceName", "sourceName")), "some/path/to/some/image.jpg");
        }

        public class FocalCrop : FocalExtensionsTests
        {
            [Test]
            public void Given_a_crop_that_fits_inside_the_image_position_and_size_should_maintained()
            {
                ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(10, 10, 6, 6, 40, 40), "rect", "7,7,6,6");
            }
        }
    }
}