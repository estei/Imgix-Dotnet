using System;
using Imgix_Dotnet.Extensions.ObjectInvariantConversion;

namespace Imgix_Dotnet
{
    /// <summary>
    /// The image we link to.
    /// Object is immutable and will always return a new instance.
    /// </summary>
    public class ImgixImage
    {
        private readonly SecureUrl _url;

        /// <summary>
        /// Initializes a new ImgixImage object with a SecureUrl
        /// </summary>
        /// <param name="url">The url of the image</param>
        /// <exception cref="ArgumentNullException"><paramref name="url"/> is empty</exception>
        internal ImgixImage(SecureUrl url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            _url = url;
        }

        /// <summary>
        /// The url for the image in imgix
        /// </summary>
        public string Url => _url;

        /// <summary>
        /// Adds a new parameter to the image
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public ImgixImage AddParameter(string name, object value)
            => new ImgixImage(_url.AddParameter(name, value.ToInvariantString()));

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
            => _url.ToString();

        /// <summary>
		/// Implicit conversion from ImgixImage to String.
		/// </summary>
		/// <param name="image">the ImgixImage object</param>
		/// <returns>The string</returns>
		public static implicit operator string (ImgixImage image) => image.Url;
    }
}