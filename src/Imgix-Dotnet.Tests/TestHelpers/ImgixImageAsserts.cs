using System.Collections.Generic;
using Flurl;
using NUnit.Framework;

namespace Imgix_Dotnet.Tests.TestHelpers
{
    public static class ImgixImageAsserts
    {
        public static void HasQueryParameter(ImgixImage subject, string name, string value)
        {
            Assert.True(new Url(subject).QueryParams.Contains(new KeyValuePair<string, object>(name, value)), $"Expected image url[{subject}] to have query parameter {name}={value} but it was not found.");
        }
    }
}