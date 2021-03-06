﻿using Imgix_Dotnet.Operations.FaceDetection;
using Imgix_Dotnet.Tests.TestHelpers;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.Operations
{
    [TestFixture]
    public class FaceDetectionExtensionsTests : OperationsTests
    {
        public class FaceIndex : FaceDetectionExtensionsTests
        {
            [Test]
            public void Given_an_int_the_method_should_add_a_faceindex_parameter_with_integer_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.FaceIndex(1), "faceindex", "1");
            }
        }

        public class FacePad : FaceDetectionExtensionsTests
        {
            [Test]
            public void Given_a_float_the_method_should_add_a_facepad_parameter_with_float_as_value()
            {
                ImgixImageAsserts.HasQueryParameter(Image.FacePad(1.1), "facepad", "1.1");
            }
        }

        public class Faces : FaceDetectionExtensionsTests
        {
            [Test]
            public void The_method_should_add_a_faces_parameter_with_a_value_of_1()
            {
                ImgixImageAsserts.HasQueryParameter(Image.Faces(), "faces", "1");
            }
        }
    }
}