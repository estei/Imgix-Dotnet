namespace Imgix_LinkBuilder.Transforms
{
    /// <summary>
    /// ImgixImage extension methods that sets watermark related parameters on the Url.
    /// </summary>
    public static class WatermarkExtensions
    {
        /// <summary>
        /// Adds a watermark to the image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The URL to the image used as watermark.
        ///     Can be relative or absolute
        ///     See the documentation for restrictions
        /// </param>
        /// <returns></returns>
        public static ImgixImage Mark(this ImgixImage image, string value)
            => image.AddParameter("mark", value);

        /// <summary>
        /// Aligns the watermark image inside the source image.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: top, middle, bottom, left, center, and right
        ///     Default: bottom,right
        ///     Multiple values can be set seperated by comma
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkAlign(this ImgixImage image, string value)
            => image.AddParameter("markalign", value);

        /// <summary>
        /// Adjusts the alpha blend of the watermark
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0-100
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkAlpha(this ImgixImage image, int value)
            => image.AddParameter("markalpha", value);

        /// <summary>
        /// Sets the base url watermarks.
        /// This is mostly for setting in the imgix backend to keep urls short.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The base url for your watermarks.
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkBase(this ImgixImage image, string value)
            => image.AddParameter("markbase", value);

        /// <summary>
        /// Sets the watermark fit mode.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: clip, crop, max, and scale
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkFit(this ImgixImage image, string value)
            => image.AddParameter("markfit", value);

        /// <summary>
        /// Sets the watermark height
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The height in pixels
        ///     Max: 2000
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkHeight(this ImgixImage image, int value)
            => image.AddParameter("markh", value);

        /// <summary>
        /// Sets the watermark height ratio
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The size ratio compared to its original size.
        ///     Vaalues: 0.0 - 1.0
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkHeight(this ImgixImage image, double value)
            => image.AddParameter("markh", value);

        /// <summary>
        /// Sets the watermark width
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The width in pixels
        ///     Max: 2000
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkWidth(this ImgixImage image, int value)
            => image.AddParameter("markw", value);

        /// <summary>
        /// Sets the watermark width ratio
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The size ratio compared to its original size.
        ///     Vaalues: 0.0 - 1.0
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkWidth(this ImgixImage image, double value)
            => image.AddParameter("markw", value);

        /// <summary>
        /// The padding around the watermark
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The amoount of padding in pixels.
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkPadding(this ImgixImage image, int value)
            => image.AddParameter("markpad", value);

        /// <summary>
        /// Watermark size scaled as a percentage
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The size as percentage
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkScale(this ImgixImage image, int value)
            => image.AddParameter("markscale", value);

        /// <summary>
        /// Absolute horizontal position of the watermark from the aligned edge.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Pixels from the edge
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkXPosition(this ImgixImage image, int value)
            => image.AddParameter("markx", value);

        /// <summary>
        /// Absolute vertical position of the watermark from the aligned edge.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Pixels from the edge
        /// </param>
        /// <returns></returns>
        public static ImgixImage MarkYPosition(this ImgixImage image, int value)
            => image.AddParameter("marky", value);

    }
}