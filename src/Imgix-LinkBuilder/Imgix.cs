using System;

namespace Imgix_LinkBuilder
{
    /// <summary>
    /// The Imgix url builder.
    /// </summary>
    public class Imgix
    {
        private readonly string _source;
        private readonly bool _useHttps;
        private readonly string _secureUrlToken;

        /// <summary>
        /// The base constructor.
        /// Sets up the Imgix url builder base options.
        /// </summary>
        /// <param name="options"></param>
        public Imgix(IImgixOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            _source = options.SourceName;
            _useHttps = options.UseHttps;
            _secureUrlToken = options.SecureUrlToken;
        }

        /// <summary>
        /// Creates a new imgix image from with the obtions in this Imgix
        /// </summary>
        /// <param name="path">The path to the image</param>
        /// <returns></returns>
        public ImgixImage NewImage(string path)
        {
            var escapedPath = path.StartsWith("http") ? Uri.EscapeDataString(path) : Uri.EscapeUriString(path).Replace("?", "%3F");
            return new ImgixImage(new SecureUrl(_useHttps ? "https" : "http", _source + ".imgix.net", escapedPath, _secureUrlToken, ""));
        }

        /// <summary>
        /// Creates a new imgix image from a supplied options object
        /// </summary>
        /// <param name="options">The base options</param>
        /// <param name="path">The path to the image</param>
        /// <returns></returns>
        public static ImgixImage NewImage(IImgixOptions options, string path) => new Imgix(options).NewImage(path);

        /// <summary>
        /// Creates a new imgix image from a supplied sourceName and path
        /// </summary>
        /// <param name="sourceName">The source name</param>
        /// <param name="path">The path to the image</param>
        /// <param name="useHttps">Is the source https. Default: true</param>
        /// <returns></returns>
        public static ImgixImage NewImage(string sourceName, string path, bool useHttps = true) => NewImage(new ImgixOptions(sourceName, useHttps), path);
    }
}