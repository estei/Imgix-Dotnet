using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests
{
    [TestFixture]
    public class ImgixTests
    {
        private string _imagePath;
        private string _sourceName;

        [SetUp]
        public void MainFixtureInit()
        {
            _imagePath = "heyhey/hey.jpg";
            _sourceName = "TestSource";
        }

        private class NewImage : ImgixTests
        {
            [Test]
            public void Should_create_new_image_with_the_given_path()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Should_create_new_image_with_the_source_in_options()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.Contains(_sourceName));
            }

            [Test]
            public void Should_create_new_image_using_https_if_in_option()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName, true));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Should_create_new_image_using_http_if_useHttps_is_false_in_options()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName, false));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }

            [Test]
            public void Static_version_Should_create_a_new_image_with_the_given_path()
            {
                string result = Imgix.NewImage(new ImgixOptions(_sourceName), _imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Static_version_Should_create_a_new_image_with_the_source_in_options()
            {
                string result = Imgix.NewImage(new ImgixOptions(_sourceName), _imagePath);
                Assert.True(result.Contains(_sourceName));
            }

            [Test]
            public void Static_version_Should_create_a_new_image_using_https_if_in_option()
            {
                string result = Imgix.NewImage(new ImgixOptions(_sourceName, true), _imagePath);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Static_version_Should_create_a_new_image_using_http_useHttps_is_false_in_options()
            {
                string result = Imgix.NewImage(new ImgixOptions(_sourceName, false), _imagePath);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }
        }
    }
}