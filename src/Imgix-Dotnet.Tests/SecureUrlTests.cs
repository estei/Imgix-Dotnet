using Imgix_Dotnet.Configuration;
using Imgix_Dotnet.Operations.Size;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests
{
    [TestFixture]
    public class SecureUrlTests
    {
        [Test]
        public void Given_A_fully_qualified_url_in_path_it_should_sign_the_url_correctly()
        {
            //Arrange
            var image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("TestSource", "FOO123bar", "TestSource")), "http://avatars.com/john-smith.png");
            //Act
            //Assert
            ImgixImageAsserts.HasQueryParameter(image, "s", "493a52f008c91416351f8b33d4883135");
        }

        [Test]
        public void Given_A_fully_qualified_url_in_path_and_a_width_and_a_height_it_should_sign_the_url_correctly()
        {
            //Arrange
            var image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("TestSource", "FOO123bar", "TestSource")), "http://avatars.com/john-smith.png");

            //Act
            var result = image.Width(400).Height(300);
            //Assert
            ImgixImageAsserts.HasQueryParameter(result, "s", "61ea1cc7add87653bb0695fe25f2b534");
        }

        [Test]
        public void Given_a_simple_path_it_should_sign_the_url_correctly()
        {
            //Arrange
            var image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("TestSource", "FOO123bar", "TestSource")), "/users/1.png");
            //Act
            //Assert
            ImgixImageAsserts.HasQueryParameter(image, "s", "6797c24146142d5b40bde3141fd3600c");
        }

        [Test]
        public void Given_a_simple_path_with_width_and_height_it_should_sign_the_url_correctly()
        {
            //Arrange
            var image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("TestSource", "FOO123bar", "TestSource")), "/users/1.png");
            //Act
            var result = image.Width(400).Height(300);
            //Assert
            ImgixImageAsserts.HasQueryParameter(result, "s", "c7b86f666a832434dd38577e38cf86d1");
        }

        [Test]
        public void Given_no_token_the_url_should_not_be_signed()
        {
            //Arrange
            var image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("TestSource", "TestSourceHost")), "/users/1.png");
            //Act
            var result = image.Width(400).Height(300);
            //Assert
            Assert.False(result.ToString().Contains("s="));
        }
    }
}