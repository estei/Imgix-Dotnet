using Imgix_Dotnet.Configuration;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Operations
{
    public class OperationsTests
    {
        internal ImgixImage Image;

        [SetUp]
        public void MainFixtureInit()
        {
            Image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("sourceName", "sourceName")), "some/path/to/some/image.jpg");
        }
    }
}