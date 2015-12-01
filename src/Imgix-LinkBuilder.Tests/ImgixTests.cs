using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests
{
    [TestFixture]
    public class ImgixTests
    {
        private string _imagePath;
        private string _sourceName;
        private string _host;

        [SetUp]
        public void MainFixtureInit()
        {
            _imagePath = "heyhey/hey.jpg";
            _sourceName = "TestSource";
            _host = "hey.com";
        }

        private class NewImage : ImgixTests
        {
            [Test]
            public void Given_a_path_it_should_create_a_new_image_with_the_given_path()
            {
                var subject = new Imgix(new ImgixOptions(new ImgixSource(_sourceName, _host)));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }
        }

        private class NewImage_static : ImgixTests
        {
            [Test]
            public void Given_options_object_and_a_path_it_should_create_a_new_image_with_the_supplied_path()
            {
                string result = Imgix.NewImage(new ImgixOptions(new ImgixSource(_sourceName, _host)), _imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Given_options_object_with_useHttps_true_and_a_path_it_should_create_a_new_image_using_https()
            {
                string result = Imgix.NewImage(new ImgixOptions(new ImgixSource(_sourceName, _host, true)), _imagePath);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Given_options_object_with_useHttps_false_it_should_create_a_new_image_using_http()
            {
                string result = Imgix.NewImage(new ImgixOptions(new ImgixSource(_sourceName, _host, false)), _imagePath);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }

            [Test]
            public void Given_sourceName_imagePath_it_should_create_a_new_image_with_path()
            {
                string result = Imgix.NewImage(_sourceName, _imagePath, _host);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Given_no_useHttps_it_should_create_a_new_image_using_https()
            {
                string result = Imgix.NewImage(_sourceName, _imagePath, _host);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Given_useHttps_is_false_it_should_create_a_new_image_using_http()
            {
                string result = Imgix.NewImage(_sourceName, _imagePath, _host, false);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }
        }
    }
}