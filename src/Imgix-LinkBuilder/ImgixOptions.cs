using System;

namespace Imgix_LinkBuilder
{
    /// <summary>
    /// Basic options
    /// </summary>
    public class ImgixOptions : IImgixOptions
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="sourceName">The sourcename to to insert into Urls</param>
        /// <param name="useHttps">Should Urls use https instead of http</param>
        /// <param name="secureUrlToken">A token used when signing urls</param>
        public ImgixOptions(string sourceName, bool useHttps = true, string secureUrlToken = "")
        {
            if (sourceName == null) throw new ArgumentNullException(nameof(sourceName));
            SourceName = sourceName;
            UseHttps = useHttps;
            SecureUrlToken = secureUrlToken;
        }

        /// <summary>
        /// should return the source name in imgix.
        /// </summary>
        public string SourceName { get; }

        /// <summary>
        /// Should the builder use https
        /// </summary>
        public bool UseHttps { get; }

        /// <summary>
        /// The token used for signing urls
        /// </summary>
        public string SecureUrlToken { get; }
    }
}