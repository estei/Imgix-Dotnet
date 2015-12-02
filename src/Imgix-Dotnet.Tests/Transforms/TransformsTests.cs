using Imgix_Dotnet.Configuration;
using Imgix_Dotnet;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Transforms
{
    public class TransformsTests
    {
        internal ImgixImage Image;

        [SetUp]
        public void MainFixtureInit()
        {
            Image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("sourceName", "sourceName")), "some/path/to/some/image.jpg");
        }
    }
}