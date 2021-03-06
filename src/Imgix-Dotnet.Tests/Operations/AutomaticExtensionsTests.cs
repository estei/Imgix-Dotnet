﻿using Imgix_Dotnet.Operations.Automatic;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Operations
{
    [TestFixture]
    public class AutomaticExtensionsTests : OperationsTests
    {
        public class Auto : AutomaticExtensionsTests
        {
            [Test]
            public void Given_a_string_an_auto_parameter_is_added_with_the_string_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto("enhance"), "auto", "enhance");
            }

            [Test]
            public void Given_an_AutoTransform_Enhance_an_auto_parameter_enhance_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto(AutoOperation.Enhance), "auto", "enhance");
            }

            [Test]
            public void Given_an_AutoTransform_Redeye_an_auto_parameter_redeye_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto(AutoOperation.Redeye), "auto", "redeye");
            }

            [Test]
            public void Given_an_AutoTransform_Format_an_auto_parameter_format_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto(AutoOperation.Format), "auto", "format");
            }

            [Test]
            public void Given_multiple_AutoTransform_it_will_add_them_all_seperated_by_commas()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Auto(AutoOperation.Format, AutoOperation.Redeye), "auto", "format,redeye");
            }
        }
    }
}