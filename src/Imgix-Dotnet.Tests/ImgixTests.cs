using System;
using System.Collections.Generic;
using Imgix_Dotnet.Configuration;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests
{
    [TestFixture]
    public class ImgixTests
    {
        private string _imagePath;
        private string _sourceName;
        private string _host;

        [SetUp]
        public void MainFixtureInit()
        {
            _imagePath = "heyhey/hey.jpg";
            _sourceName = "TestSource";
            _host = "hey.com";
        }

        private class NewImage : ImgixTests
        {
            private Imgix _subject;

            [SetUp]
            public void Init()
            {
                _subject = new Imgix(new ImgixOptions(new ImgixSource(_sourceName, _host)));
            }

            [Test]
            public void Given_a_path_it_should_create_a_new_image_with_the_given_path()
            {
                string result = _subject.NewImage(_imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Given_a_sourceName_and_path_it_should_create_a_new_image_with_the_given_path()
            {
                string result = _subject.NewImage(_sourceName, _imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Given_an_empty_path_it_should_throw_an_ArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _subject.NewImage(_sourceName, ""));
            }

            [Test]
            public void Given_a_null_path_it_should_throw_an_ArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _subject.NewImage(_sourceName, null));
            }

            [Test]
            public void Given_a_null_sourceName_it_should_throw_an_ArgumentException()
            {
                string sourceName = null;
// ReSharper disable ExpressionIsAlwaysNull
                Assert.Throws<ArgumentException>(() => _subject.NewImage(sourceName, _imagePath));
// ReSharper restore ExpressionIsAlwaysNull
            }

            [Test]
            public void Given_an_empty_sourceName_it_should_throw_an_ArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _subject.NewImage("", _imagePath));
            }

            [Test]
            public void Given_a_sourceName_that_does_not_exist_it_should_throw_a_KeyNotFoundException()
            {
                Assert.Throws<KeyNotFoundException>(() => _subject.NewImage("No source here", _imagePath));
            }
        }

        private class CreateImage : ImgixTests
        {
            [Test]
            public void Given_an_options_object_and_a_path_it_should_create_a_new_image_with_the_supplied_path()
            {
                string result = Imgix.CreateImage(new ImgixOptions(new ImgixSource(_sourceName, _host)), _imagePath);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Given_an_options_object_with_useHttps_true_and_a_path_it_should_create_a_new_image_using_https()
            {
                string result = Imgix.CreateImage(new ImgixOptions(new ImgixSource(_sourceName, _host, true)), _imagePath);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Given_an_options_object_with_useHttps_false_it_should_create_a_new_image_using_http()
            {
                string result = Imgix.CreateImage(new ImgixOptions(new ImgixSource(_sourceName, _host, false)), _imagePath);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }

            [Test]
            public void Given_imagePath_and_host_it_should_create_a_new_image_with_path()
            {
                string result = Imgix.CreateImage(_imagePath, _host);
                Assert.True(result.EndsWith(_imagePath));
            }

            [Test]
            public void Given_imagePath_and_host_it_should_create_a_new_image_with_host()
            {
                string result = Imgix.CreateImage(_imagePath, _host);
                Assert.AreEqual(_host, new Uri(result).Host);
            }

            [Test]
            public void Given_no_useHttps_it_should_create_a_new_image_using_https()
            {
                string result = Imgix.CreateImage(_imagePath, _host);
                Assert.True(result.StartsWith("https"));
            }

            [Test]
            public void Given_useHttps_is_false_it_should_create_a_new_image_using_http()
            {
                string result = Imgix.CreateImage(_imagePath, _host, false);
                Assert.True(result.StartsWith("http"));
                Assert.False(result.StartsWith("https"));
            }
        }
    }
}