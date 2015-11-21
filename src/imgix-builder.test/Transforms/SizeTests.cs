using System.Globalization;
using imgix_builder.test.TestHelpers;
using imgix_builder.Transforms;
using NUnit.Framework;

namespace imgix_builder.test.Transforms
{
    [TestFixture]
    public class SizeTests
    {
        private ImgixImage _image;

        [SetUp]
        public void MainFixtureInit()
        {
            _image = Imgix.NewImage(new ImgixOptions("sourceName"), "some/path/to/some/image.jpg");
        }
        private class Rect_with_dimensions_string : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_rect_with_value_from_dimensions()
            {
                //Arrange
                const string dimensions = "0,0,200,200";
                //Act
                var result = _image.Rect(dimensions);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "rect", dimensions);
            }
        }

        private class Rect_with_seperate_integers : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_rect_with_values_given()
            {
                //Arrange
                const int x = 100;
                const int y = 50;
                const int width = 200;
                const int height = 200;
                var expectedDimensions = $"{x},{y},{width},{height}";
                //Act
                var result = _image.Rect(x,y,width,height);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "rect", expectedDimensions);
            }
        }

        private class Height_with_integer : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_h_with_the_given_integer_value()
            {
                //Arrange
                var height = 200;
                //Act
                var result = _image.Height(height);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "h", height.ToString());
            }
        }
        private class Height_with_float : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_h_with_the_given_float_value()
            {
                //Arrange
                var height = 0.9;
                //Act
                var result = _image.Height(height);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "h", height.ToString(CultureInfo.InvariantCulture));
            }
        }

        private class Height_with_string : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_h_with_the_given_float_value()
            {
                //Arrange
                const string height = "0.9";
                //Act
                var result = _image.Height(height);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "h", height);
            }
        }

        private class Width_with_integer : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_w_with_the_given_integer_value()
            {
                //Arrange
                const int width = 200;
                //Act
                var result = _image.Width(width);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "w", width.ToString());
            }
        }
        private class Width_with_float : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_w_with_the_given_float_value()
            {
                //Arrange
                const double width = 0.9;
                //Act
                var result = _image.Width(width);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "w", width.ToString(CultureInfo.InvariantCulture));
            }
        }

        private class Width_with_string : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_w_with_the_given_string_value()
            {
                //Arrange
                const string width = "0.9";
                //Act
                var result = _image.Width(width);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "w", width);
            }
        }

        private class Crop_with_string : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_crop_with_the_given_string_value()
            {
                //Arrange
                const string crop = "top";
                //Act
                var result = _image.Crop(crop);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "crop", crop);
            }
        }

        private class Fit_with_string : SizeTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_fit_with_the_given_string_value()
            {
                //Arrange
                const string fit = "clip";
                //Act
                var result = _image.Fit(fit);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "fit", fit);
            }
        }
    }
}