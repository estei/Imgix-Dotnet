using Imgix_LinkBuilder.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests
{
    [TestFixture]
    public class ImgixImageTests
    {
        private string _imagePath;
        private string _sourceName;

        [SetUp]
        public void MainFixtureInit()
        {
            _imagePath = "heyhey/hey.jpg";
            _sourceName = "TestSource";
        }

        private class AddParameter : ImgixImageTests
        {
            private ImgixImage _image;

            [SetUp]
            public void Init()
            {
                _image = Imgix.NewImage(new ImgixOptions(_sourceName), _imagePath);
            }
            [Test]
            public void Should_return_a_new_image_object()
            {
                //Arrange
                //Act
                var result1 = _image.AddParameter("test1", "test1");
                var result2 = _image.AddParameter("test2", "test2");
                //Assert
                Assert.AreNotEqual(result1.Url, result2.Url);
                Assert.False(result1.Url.Contains("test2"));
                Assert.False(result2.Url.Contains("test1"));
            }

            [Test]
            public void Should_add_parameter_to_new_image_object()
            {
                //Arrange
                var image = Imgix.NewImage(new ImgixOptions(_sourceName), _imagePath);
                //Act
                var result = image.AddParameter("test1", "test1");
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "test1", "test1");
            }
        }
    }
}