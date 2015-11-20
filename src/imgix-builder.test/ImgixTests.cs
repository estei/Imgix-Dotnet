using NUnit.Framework;

namespace imgix_builder.test
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

        class NewImage : ImgixTests
        {
            [Test]
            public void Should_create_new_image_with_the_given_path()
            {
                var subject = new Imgix(new ImgixOptions(_sourceName));
                string result = subject.NewImage(_imagePath);
                Assert.True(result.EndsWith(_imagePath));
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
        }
    }
}