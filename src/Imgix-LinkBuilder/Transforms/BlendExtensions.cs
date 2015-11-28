namespace Imgix_LinkBuilder.Transforms
{
    /// <summary>
    /// ImgixImage extension methods that sets blend related parameters on the Url.
    /// </summary>
    public static class BlendExtensions
    {
        /// <summary>
        /// Blend the image with either a color or a different image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values:
        ///     Color: 3, 6 or 8 char hexadecimal color.
        ///     Image: A url to the image.
        /// </param>
        /// <returns></returns>
        public static ImgixImage Blend(this ImgixImage image, string value)
            => image.AddParameter("blend", value);

        /// <summary>
        /// How is the blending supposed to happen
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: color, burn, dodge, darken, difference, exclusion, hardlight, hue, lighten, luminosity, multiply, overlay, saturation, screen, softlight, and normal
        /// </param>
        /// <returns></returns>
        public static ImgixImage BlendMode(this ImgixImage image, string value)
            => image.AddParameter("bm", value);

        /// <summary>
        /// Adjusts the alignment of the image being applied to the source image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     One or more of the following values seperated by comma
        ///     Values: top, middle, bottom, left, center, and right
        /// </param>
        /// <returns></returns>
        public static ImgixImage BlendAlign(this ImgixImage image, string value)
            => image.AddParameter("ba", value);

        /// <summary>
        /// Sets the transparency of the blend image or color
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0-100
        ///          0: Fully transparant
        ///        100: Fully opaque
        /// </param>
        /// <returns></returns>
        public static ImgixImage BlendAlpha(this ImgixImage image, int value)
            => image.AddParameter("balpha", value.ToString());

        /// <summary>
        /// Padds the blending image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The amount of pixels that the image will be padded
        /// </param>
        /// <returns></returns>
        public static ImgixImage BlendPadding(this ImgixImage image, int value)
            => image.AddParameter("bp", value.ToString());

        /// <summary>
        /// The width of the blend image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The width of the image
        /// </param>
        /// <returns></returns>
        public static ImgixImage BlendWidth(this ImgixImage image, int value)
            => image.AddParameter("bw", value);

        /// <summary>
        /// The height of the blend image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The height of the image
        /// </param>
        /// <returns></returns>
        public static ImgixImage BlendHeight(this ImgixImage image, int value)
            => image.AddParameter("bh", value);

        /// <summary>
        /// How is the blend image fit to its bw and or bh dimensions
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: clamp, clip, crop, max, and scale
        /// </param>
        /// <returns></returns>
        public static ImgixImage BlendFit(this ImgixImage image, string value)
            => image.AddParameter("bf", value);
    }
}