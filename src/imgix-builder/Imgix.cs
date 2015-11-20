using System;
using Flurl;

namespace imgix_builder
{
    public class Imgix
    {
        private readonly string _source;
        private readonly bool _useHttps;

        public Imgix(IImgixOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            _source = options.SourceName;
            _useHttps = options.UseHttps;
        }

        /// <summary>
        /// Creates a new imgix image from with the obtions in this Imgix
        /// </summary>
        /// <param name="path">The path to the image</param>
        /// <returns></returns>
        public ImgixImage NewImage(string path) => new ImgixImage(new Url($"{(_useHttps ? "https" : "http")}://{_source}.imgix.net".AppendPathSegment(path)));

        /// <summary>
        /// Creates a new imgix image from a supplied options object
        /// </summary>
        /// <param name="options">The base options</param>
        /// <param name="path">The path to the image</param>
        /// <returns></returns>
        public static ImgixImage NewImage(IImgixOptions options, string path) => new Imgix(options).NewImage(path);
    }
}