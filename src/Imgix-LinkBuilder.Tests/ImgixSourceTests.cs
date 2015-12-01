using NUnit.Framework;

namespace Imgix_LinkBuilder.Tests
{
    [TestFixture]
    public class ImgixSourceTests
    {
        public class GetUrl : ImgixSourceTests
        {
            [Test]
            public void Given_a_path_it_should_return_a_url_with_that_path()
            {
                var subject = new ImgixSource("testhost", "testhost.imgix.net");
                var result = subject.GetUrl("hey/hey.jpg");
                Assert.True(result.ToString().Contains("hey/hey.jpg"));
            }
        }
    }
}