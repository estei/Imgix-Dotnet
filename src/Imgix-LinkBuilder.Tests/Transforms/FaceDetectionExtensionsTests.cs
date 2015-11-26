using Imgix_LinkBuilder.Tests.TestHelpers;
using Imgix_LinkBuilder.Transforms.FaceDetection;
using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests.Transforms
{
    [TestFixture]
    public class FaceDetectionExtensionsTests
    {
        private ImgixImage _image;

        [SetUp]
        public void MainFixtureInit()
        {
            _image = Imgix.NewImage(new ImgixOptions("sourceName"), "some/path/to/some/image.jpg");
        }

        public class FaceIndex : FaceDetectionExtensionsTests
        {
            [Test]
            public void Given_an_int_the_method_should_add_a_faceindex_parameter_with_integer_as_value()
            {
                var result = _image.FaceIndex(1);
                ImgixImageAsserts.HasQueryParameter(result, "faceindex", "1");
            }
        }

        public class FacePad : FaceDetectionExtensionsTests
        {
            [Test]
            public void Given_a_float_the_method_should_add_a_facepad_parameter_with_float_as_value()
            {
                var result = _image.FacePad(1.1);
                ImgixImageAsserts.HasQueryParameter(result, "facepad", "1.1");
            }
        }

        public class Faces : FaceDetectionExtensionsTests
        {
            [Test]
            public void The_method_should_add_a_faces_parameter_with_a_value_of_1()
            {
                var result = _image.Faces();
                ImgixImageAsserts.HasQueryParameter(result, "faces", "1");
            }
        }
    }
}