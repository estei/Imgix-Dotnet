using Imgix_Dotnet.Configuration;
using Imgix_Dotnet.Macros;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Macros
{
    [TestFixture]
    public class FocalExtensionsTests
    {
        internal ImgixImage Image;

        [SetUp]
        public void MainFixtureInit()
        {
            Image = Imgix.CreateImage(new ImgixOptions(new ImgixSource("sourceName", "sourceName")), "some/path/to/some/image.jpg");
        }

        public class FocalCrop : FocalExtensionsTests
        {
            public class GivenCropThatFitsInside : FocalCrop
            {
                [Test]
                public void Then_position_and_size_should_maintained()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(10, 10, 6, 6, 40, 40), "rect", "7,7,6,6");
                }

                [Test]
                public void But_sticks_out_to_the_left_then_position_should_be_moved_to_left_side_of_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(1, 10, 6, 6, 40, 40), "rect", "0,7,6,6");
                }

                [Test]
                public void But_sticks_out_to_the_right_then_position_should_be_moved_to_fit_on_right_side()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(38, 10, 6, 6, 40, 40), "rect", "34,7,6,6");
                }

                [Test]
                public void But_sticks_out_on_top_then_position_should_be_moved_to_fit_on_top()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(10, 1, 6, 6, 40, 40), "rect", "7,0,6,6");
                }

                [Test]
                public void But_sticks_out_on_the_bottom_then_position_should_be_moved_to_fit_on_the_bottom()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(10, 38, 6, 6, 40, 40), "rect", "7,34,6,6");
                }
            }

            public class GivenCropThatIsLarger : FocalCrop
            {
                [Test]
                public void The_crop_should_shrink_to_fit_inside_the_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(10, 10, 50, 50, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void And_a_different_aspect_from_the_image_the_crop_should_shrink_to_fit_inside_the_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(10, 10, 50, 40, 40, 40), "rect", "0,0,40,32");
                }
            }

            public class GivenCropThatFitsInsideAndPercentagePositioned : FocalCrop
            {
                [Test]
                public void Then_position_and_size_should_maintained()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(0.5, 0.5, 6, 6, 40, 40), "rect", "17,17,6,6");
                }

                [Test]
                public void But_sticks_out_to_the_left_then_position_should_be_moved_to_left_side_of_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(0.1, 0.5, 10, 10, 40, 40), "rect", "0,15,10,10");
                }

                [Test]
                public void But_sticks_out_to_the_right_then_position_should_be_moved_to_fit_on_right_side()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(0.99, 0.5, 6, 6, 40, 40), "rect", "34,17,6,6");
                }

                [Test]
                public void But_sticks_out_on_top_then_position_should_be_moved_to_fit_on_top()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(0.5, 0.1, 10, 10, 40, 40), "rect", "15,0,10,10");
                }

                [Test]
                public void But_sticks_out_on_the_bottom_then_position_should_be_moved_to_fit_on_the_bottom()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(0.5, 0.99, 6, 6, 40, 40), "rect", "17,34,6,6");
                }
            }

            public class GivenCropThatIsLargerAndPercentagePositioned : FocalCrop
            {
                [Test]
                public void The_crop_should_shrink_to_fit_inside_the_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(0.5, 0.5, 50, 50, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void And_a_different_aspect_from_the_image_the_crop_should_shrink_to_fit_inside_the_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalCrop(0.5, 0.5, 50, 40, 40, 40), "rect", "0,4,40,32");
                }
            }

        }

        public class FocalResize : FocalExtensionsTests
        {
            public class GivenSizeThatFitsInside : FocalResize
            {
                [Test]
                public void Then_grow_the_crop_to_match_the_image_before_resizing()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(10, 10, 6, 6, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void
                    But_sticks_out_to_the_left_then_position_should_be_moved_to_left_side_of_image_and_grow_to_match()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(1, 10, 6, 6, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void
                    But_sticks_out_to_the_right_then_position_should_be_moved_to_fit_on_right_of_image_and_grow_to_match
                    ()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(38, 10, 6, 6, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void But_sticks_out_on_top_then_position_should_be_moved_to_fit_on_top_and_grow_to_match()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(10, 1, 6, 6, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void
                    But_sticks_out_on_the_bottom_then_position_should_be_moved_to_fit_on_the_bottom_and_grow_to_match()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(10, 38, 6, 6, 40, 40), "rect", "0,0,40,40");
                }
            }

            public class GivenCropThatIsLarger : FocalResize
            {
                [Test]
                public void The_crop_should_shrink_to_fit_inside_the_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(10, 10, 50, 50, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void And_a_different_aspect_from_the_image_the_crop_should_shrink_to_fit_inside_the_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(10, 10, 50, 40, 40, 40), "rect", "0,0,40,32");
                }

                [Test]
                public void It_should_not_stretch_the_cropped_image()
                {
                    var result = Image.FocalResize(10, 10, 50, 40, 40, 40);
                    Assert.False(result.ToString().Contains("w="));
                    Assert.False(result.ToString().Contains("h="));
                }
            }

            public class GivenCropThatFitsInsideAndPercentagePositioned : FocalResize
            {
                [Test]
                public void Then_grow_the_crop_to_match_the_image_before_resizing()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.5, 0.5, 6, 6, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void
                    But_sticks_out_to_the_left_then_position_should_be_moved_to_left_side_of_image_and_grow_to_match()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.1, 0.5, 10, 10, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void
                    But_sticks_out_to_the_right_then_position_should_be_moved_to_fit_on_right_of_image_and_grow_to_match
                    ()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.99, 0.5, 6, 6, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void But_sticks_out_on_top_then_position_should_be_moved_to_fit_on_top_and_grow_to_match()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.5, 0.1, 10, 10, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void
                    But_sticks_out_on_the_bottom_then_position_should_be_moved_to_fit_on_the_bottom_and_grow_to_match()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.5, 0.99, 6, 6, 40, 40), "rect", "0,0,40,40");
                }
            }

            public class GivenCropThatIsLargerAndPercentagePositioned : FocalResize
            {
                [Test]
                public void The_crop_should_shrink_to_fit_inside_the_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.5, 0.5, 50, 50, 40, 40), "rect", "0,0,40,40");
                }

                [Test]
                public void And_a_different_aspect_from_the_image_the_crop_should_shrink_to_fit_inside_the_image()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.5, 0.5, 50, 40, 40, 40), "rect", "0,4,40,32");
                }

                [Test]
                public void It_should_not_stretch_the_cropped_image()
                {
                    var result = Image.FocalResize(0.5, 0.5, 50, 40, 40, 40);
                    Assert.False(result.ToString().Contains("w="));
                    Assert.False(result.ToString().Contains("h="));
                }
            }

            public class GivenAWidth : FocalResize
            {
                [Test]
                public void A_w_property_should_be_added_to_the_url()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.5, 0.5, 35, 35, 40, 40), "w", "35");
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(10, 10, 35, 35, 40, 40), "w", "35");
                }
            }

            public class GivenAHeight : FocalResize
            {
                [Test]
                public void An_h_property_should_be_added_to_the_url()
                {
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(0.5, 0.5, 35, 35, 40, 40), "h", "35");
                    ImgixImageAsserts.HasQueryParameter(Image.FocalResize(10, 10, 35, 35, 40, 40), "h", "35");
                }


            }
        }
    }
}