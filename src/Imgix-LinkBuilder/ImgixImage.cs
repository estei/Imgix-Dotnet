using System;
using Flurl;

namespace Imgix_LinkBuilder
{
    /// <summary>
    /// The image we link to.
    /// Object is immutable and will always return a new instance.
    /// </summary>
    public class ImgixImage
    {
        internal ImgixImage(string url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            Url = url;
        }

        /// <summary>
        /// The url for the image in imgix
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Adds a new parameter to the image
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public ImgixImage AddParameter(string name, string value)
            => new ImgixImage(Url.SetQueryParam(name, value));

        /// <summary>
		/// Implicit conversion from ImgixImage to String.
		/// </summary>
		/// <param name="image">the ImgixImage object</param>
		/// <returns>The string</returns>
		public static implicit operator string (ImgixImage image) => image.Url;
    }
}