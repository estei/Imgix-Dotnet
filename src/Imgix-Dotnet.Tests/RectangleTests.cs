using System;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests
{
    [TestFixture]
    public class RectangleTests
    {
        public class CanHold : RectangleTests
        {
            [Test]
            public void Given_both_target_sides_are_larger_it_should_return_true()
            {
                var target = new Rectangle(2, 2);
                var subject = new Rectangle(1, 1);
                Assert.True(target.CanHold(subject));
            }

            [Test]
            public void Given_both_target_sides_are_the_same_as_subject_it_should_return_true()
            {
                var target = new Rectangle(2, 2);
                var subject = new Rectangle(2, 2);
                Assert.True(target.CanHold(subject));
            }

            [Test]
            public void Given_subject_is_taller_it_should_return_false()
            {
                var target = new Rectangle(2, 2);
                var subject = new Rectangle(2, 3);
                Assert.False(target.CanHold(subject));
            }

            [Test]
            public void Given_subject_is_wider_it_should_return_false()
            {
                var target = new Rectangle(2, 2);
                var subject = new Rectangle(3, 2);
                Assert.False(target.CanHold(subject));
            }
        }

        public class Ratio : RectangleTests
        {
            [Test]
            public void Given_target_is_larger_it_should_return_a_value_greater_than_one()
            {
                var target = new Rectangle(3, 2);
                var subject = new Rectangle(2, 2);
                var result = subject.Ratio(target);
                Assert.True(result >= 1);
            }

            [Test]
            public void Given_target_is_larger_it_should_return_the_smallest_ratio()
            {
                var target = new Rectangle(4, 3);
                var subject = new Rectangle(2, 2);
                var result = subject.Ratio(target);
                Assert.AreEqual(Convert.ToDouble(target.Height)/subject.Height, result);
            }
        }

        public class Resize : RectangleTests
        {
            [Test]
            public void Given_a_ratio_of_half_it_should_half_each_side()
            {
                var subject = new Rectangle(100, 100);
                var result = subject.Resize(0.5);
                Assert.True(result.Height == 50 && result.Width == 50);
            }

            [Test]
            public void Given_a_ratio_that_will_result_in_a_non_integer_value_it_will_round_down()
            {
                var subject = new Rectangle(99, 99);
                var result = subject.Resize(0.5);
                Assert.True(result.Height == 49 && result.Width == 49);
            }
        }

        public class EnsureFit : RectangleTests
        {
            [Test]
            public void Given_a_larger_target_it_will_return_an_equal_rectangle()
            {
                var target = new Rectangle(4, 4);
                var subject = new Rectangle(3, 3);
                var result = subject.EnsureFit(target);
                Assert.True(result.Height == 3 && result.Width == 3);
            }

            [Test]
            public void Given_a_narrower_target_it_will_return_a_rectangle_that_fits_within_target()
            {
                var target = new Rectangle(2, 4);
                var subject = new Rectangle(3, 3);
                var result = subject.EnsureFit(target);
                Assert.True(target.CanHold(result));
            }

            [Test]
            public void Given_a_smaller_in_height_target_it_will_return_a_rectangle_that_fits_within_target()
            {
                var target = new Rectangle(4, 2);
                var subject = new Rectangle(3, 3);
                var result = subject.EnsureFit(target);
                Assert.True(target.CanHold(result));
            }

            [Test]
            public void Given_a_smaller_target_the_result_will_still_have_the_same_aspect()
            {
                var target = new Rectangle(40, 20);
                var subject = new Rectangle(30, 30);
                var result = subject.EnsureFit(target);
                Assert.True(result.Height/result.Width == 1);
            }
        }

        public class Match : RectangleTests
        {
            [Test]
            public void Given_a_larger_target_it_will_return_a_rectangle_of_same_aspect_ratio_maxed_inside_target()
            {
                var target = new Rectangle(4, 4);
                var subject = new Rectangle(3, 3);
                var result = subject.Match(target);
                Assert.True(result.Height == 4 && result.Width == 4);
            }

            [Test]
            public void Given_a_narrower_target_it_will_return_a_rectangle_that_fits_within_target()
            {
                var target = new Rectangle(2, 4);
                var subject = new Rectangle(3, 3);
                var result = subject.Match(target);
                Assert.True(target.CanHold(result));
            }

            [Test]
            public void Given_a_narrower_target_it_will_return_a_rectangle_that_matches_on_width()
            {
                var target = new Rectangle(2, 4);
                var subject = new Rectangle(3, 3);
                var result = subject.Match(target);
                Assert.AreEqual(target.Width, result.Width);
            }

            [Test]
            public void Given_a_smaller_in_height_target_it_will_return_a_rectangle_that_fits_within_target()
            {
                var target = new Rectangle(4, 2);
                var subject = new Rectangle(3, 3);
                var result = subject.Match(target);
                Assert.True(target.CanHold(result));
            }

            [Test]
            public void Given_a_smaller_in_height_target_it_will_return_a_rectangle_that_matches_on_height()
            {
                var target = new Rectangle(4, 2);
                var subject = new Rectangle(3, 3);
                var result = subject.Match(target);
                Assert.AreEqual(target.Height, result.Height);
            }

            [Test]
            public void Given_a_smaller_target_the_result_will_still_have_the_same_aspect()
            {
                var target = new Rectangle(40, 20);
                var subject = new Rectangle(30, 30);
                var result = subject.Match(target);
                Assert.True(result.Height / result.Width == 1);
            }
        }
    }
}