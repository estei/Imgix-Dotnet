using NUnit.Framework;

namespace imgix_builder.test
{
    [TestFixture]
    public class ImgixTests
    {
        [Test]
        public static void Should_run()
        {
            var subject = new Imgix(new ImgixOptions {SourceName = "TestSource"});
            var result = subject.NewImage("heyhey/hey.jpg").Url;
        }

        [Test]
        public static void Should_have_a_static_version()
        {
            var result = Imgix.NewImage(new ImgixOptions { SourceName = "TestSource" },"heyhey/hey.jpg").Url;
        }
    }
}