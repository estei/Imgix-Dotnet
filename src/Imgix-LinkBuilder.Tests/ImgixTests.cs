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

        private class Ctor : ImgixTests
        {
            [Test]
            public void Given_an_options_object_images_should_be_created_with_the_source_in_options()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.Contains(_sourceName));
            }

            [Test]
            public void Given_an_options_object_images_should_be_created_using_https_if_useHttps_is_true()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName, true));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Given_an_options_object_images_should_be_created_using_http_if_useHttps_is_false()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName, false));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }
        }

        private class NewImage : ImgixTests
        {
            [Test]
            public void Given_a_path_it_should_create_a_new_image_with_the_given_path()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }
        }

        private class NewImage_static : ImgixTests
        {
            [Test]
            public void Given_options_object_and_a_path_it_should_create_a_new_image_with_the_supplied_path()
            {
                string result = Imgix.NewImage(new ImgixOptions(_sourceName), _imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Given_options_object_and_a_path_it_should_create_image_with_source_from_options()
            {
                string result = Imgix.NewImage(new ImgixOptions(_sourceName), _imagePath);
                Assert.True(result.Contains(_sourceName));
            }

            [Test]
            public void Given_options_object_with_useHttps_true_and_a_path_it_should_create_a_new_image_using_https()
            {
                string result = Imgix.NewImage(new ImgixOptions(_sourceName, true), _imagePath);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Given_options_object_with_useHttps_false_it_should_create_a_new_image_using_http()
            {
                string result = Imgix.NewImage(new ImgixOptions(_sourceName, false), _imagePath);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }

            [Test]
            public void Given_sourceName_imagePath_it_should_create_a_new_image_with_path()
            {
                string result = Imgix.NewImage(_sourceName, _imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Given_sourceName_imagePath_it_should_create_a_new_image_with_source_()
            {
                string result = Imgix.NewImage(_sourceName, _imagePath);
                Assert.True(result.Contains(_sourceName));
            }

            [Test]
            public void Given_no_useHttps_it_should_create_a_new_image_using_https()
            {
                string result = Imgix.NewImage(_sourceName, _imagePath);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Given_useHttps_is_false_it_should_create_a_new_image_using_http()
            {
                string result = Imgix.NewImage(_sourceName, _imagePath, false);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }
        }
    }
}