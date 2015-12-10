using System.Globalization;
using Imgix_Dotnet.Operations.Size;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Operations
{
    [TestFixture]
    public class SizeExtensionsTests : OperationsTests
    {
        public class Rect_with_dimensions_string : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_rect_with_value_from_dimensions()
            {
                //Arrange
                const string dimensions = "0,0,200,200";
                //Act
                var result = Image.Rect(dimensions);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "rect", dimensions);
            }
        }

        private class Rect_with_seperate_integers : SizeExtensionsTests
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
                var result = Image.Rect(x,y,width,height);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "rect", expectedDimensions);
            }
        }

        private class Height_with_integer : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_h_with_the_given_integer_value()
            {
                //Arrange
                var height = 200;
                //Act
                var result = Image.Height(height);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "h", height.ToString());
            }
        }
        private class Height_with_float : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_h_with_the_given_float_value()
            {
                //Arrange
                var height = 0.9;
                //Act
                var result = Image.Height(height);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "h", height.ToString(CultureInfo.InvariantCulture));
            }
        }

        private class Height_with_string : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_h_with_the_given_float_value()
            {
                //Arrange
                const string height = "0.9";
                //Act
                var result = Image.Height(height);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "h", height);
            }
        }

        private class Width_with_integer : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_w_with_the_given_integer_value()
            {
                //Arrange
                const int width = 200;
                //Act
                var result = Image.Width(width);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "w", width.ToString());
            }
        }
        private class Width_with_float : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_w_with_the_given_float_value()
            {
                //Arrange
                const double width = 0.9;
                //Act
                var result = Image.Width(width);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "w", width.ToString(CultureInfo.InvariantCulture));
            }
        }

        private class Width_with_string : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_w_with_the_given_string_value()
            {
                //Arrange
                const string width = "0.9";
                //Act
                var result = Image.Width(width);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "w", width);
            }
        }

        private class Crop_with_string : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_crop_with_the_given_string_value()
            {
                //Arrange
                const string crop = "top";
                //Act
                var result = Image.Crop(crop);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "crop", crop);
            }
        }

        private class Fit_with_string : SizeExtensionsTests
        {
            [Test]
            public void Should_add_a_query_parameter_called_fit_with_the_given_string_value()
            {
                //Arrange
                const string fit = "clip";
                //Act
                var result = Image.Fit(fit);
                //Assert
                ImgixImageAsserts.HasQueryParameter(result, "fit", fit);
            }
        }
    }
}