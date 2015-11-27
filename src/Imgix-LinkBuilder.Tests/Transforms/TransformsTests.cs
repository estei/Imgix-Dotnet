using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    public class TransformsTests
    {
        internal ImgixImage Image;

        [SetUp]
        public void MainFixtureInit()
        {
            Image = Imgix.NewImage(new ImgixOptions("sourceName"), "some/path/to/some/image.jpg");
        }
    }
}