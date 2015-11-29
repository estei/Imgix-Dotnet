namespace Imgix_LinkBuilder.Transforms.Stylize
{
    /// <summary>
    /// ImgixImage extension methods that sets stylize related parameters on the Url.
    /// </summary>
    public static class StylizeExtensions
    {
        /// <summary>
        /// Adds the blur parameter
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0-1000
        ///     Default: 0
        /// </param>
        /// <returns></returns>
        public static ImgixImage Blur(this ImgixImage image, int value)
            => image.AddParameter("blur", value);

        /// <summary>
        /// Adds a half-toning effect to the image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0-100
        ///     Default: 0
        /// </param>
        /// <returns></returns>
        public static ImgixImage HalfTone(this ImgixImage image, int value)
            => image.AddParameter("htn", value);

        /// <summary>
        /// Does a monochromatic hue change.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     3, 6 or 8 digit hex value
        /// </param>
        /// <returns></returns>
        public static ImgixImage Monochrome(this ImgixImage image, string value)
            => image.AddParameter("mono", value);

        /// <summary>
        /// Adds a pixellation effect
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0-100
        ///     Default: 0 (No change)
        /// </param>
        /// <returns></returns>
        public static ImgixImage Pixellate(this ImgixImage image, int value)
            => image.AddParameter("px", value);

        /// <summary>
        /// Adds a sepia toning effect to the image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0-100
        ///     Default: 0 (No change)
        /// </param>
        /// <returns></returns>
        public static ImgixImage SepiaTone(this ImgixImage image, int value)
            => image.AddParameter("sepia", value);
    }
}